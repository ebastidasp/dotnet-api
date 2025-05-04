using Microsoft.AspNetCore.Mvc;
using MyApi.Services;

[ApiController]
[Route("api")]
public class FactController : ControllerBase
{
    private readonly CatFactService _catFactService;
    private readonly GiphyService _giphyService;
    private readonly HistoryService _historyService;

    public FactController(CatFactService factService, GiphyService gifService, HistoryService historyService)
    {
        _catFactService = factService;
        _giphyService = gifService;
        _historyService = historyService;
    }

    [HttpGet("fact")]
    public async Task<IActionResult> GetFact()
    {
        var fact = await _catFactService.GetRandomFactAsync();
        return Ok(fact);
    }

    [HttpGet("gif")]
    public async Task<IActionResult> GetGif([FromQuery] string query, string fullFact, int length)
    {
        var result = await _giphyService.GetGifUrlFromQueryAsync(query);
        if (result?.Url != null)
        {
            await _historyService.AddToHistoryAsync(query, result.Url, fullFact, length);
            return Ok(result);            // <-- returns a bare string in JSON
        }
        return NotFound();
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetHistory([FromQuery] int page = 1, [FromQuery] int limit = 15)
    {
        var history = await _historyService.GetPagedAsync(page, limit);
        return Ok(history);
    }
}
