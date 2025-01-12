using Microsoft.EntityFrameworkCore;

namespace School_Management_System.Core.Wrappers
{
    public static class IQueryableExtension
    {
        public static async Task<PaginatedResult<T>> ToPaginatedList<T>(this IQueryable<T> source,
            int pageNumber, int pageSize)
            where T : class
        {
            if (source is null)
                throw new NullReferenceException();

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize > 10 ? 10 : pageSize;

            var count = await source.AsNoTracking().CountAsync();
            if (count == 0)
                return new PaginatedResult<T>(new List<T>(), pageNumber, pageSize, false, "Empty data list");

            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResult<T>(items, pageNumber, pageSize, true, "Paginated data list");
        }
    }
}
