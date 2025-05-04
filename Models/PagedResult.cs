using System.Collections.Generic;

public class PagedResult<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int Limit { get; set; }
}
