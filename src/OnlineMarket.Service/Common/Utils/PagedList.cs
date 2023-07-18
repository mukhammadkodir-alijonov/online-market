using Microsoft.EntityFrameworkCore;

namespace OnlineMarket.Service.Common.Utils;

public class PagedList<T> : List<T>
{
    public PaginationMetaData MetaData { get; set; } = default!;

    public PagedList(List<T> items, int totalAmount, PaginationParams @params)
    {
        this.MetaData = new PaginationMetaData(totalAmount, @params.PageNumber, @params.PageSize);
        AddRange(items);
    }

    public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, PaginationParams @params)
    {
        int totalAmount = source.Count();

        var items = await source.Skip((@params.PageNumber-1)*@params.PageSize)
                          .Take(@params.PageSize)
                          .ToListAsync();

        return new PagedList<T>(items, totalAmount, @params);
    }
}
