using MyApi.Models;
using MyApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Services;

public class HistoryService
{
    private readonly AppDbContext _context;

    public HistoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddToHistoryAsync(string query, string gifUrl, string fullFact, int length)
    {
        var history = new SearchHistory
        {
            Query = query,
            GifUrl = gifUrl,
            Fact = fullFact,
            Length = length,
            Timestamp = DateTime.UtcNow
        };

        _context.SearchHistories.Add(history);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResult<SearchHistory>> GetPagedAsync(int page, int limit)
    {
        var totalItems = await _context.SearchHistories.CountAsync();

        var items = await _context.SearchHistories
            .OrderByDescending(h => h.Timestamp)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();

        var result = new PagedResult<SearchHistory>
        {
            Items = items,
            TotalItems = totalItems,
            Page = page,
            Limit = limit
        };

        return result;
    }
}
