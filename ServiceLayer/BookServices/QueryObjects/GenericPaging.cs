namespace MyFirstEfCoreApp.ServiceLayer.BookServices.QueryObjects
{
    public static class GenericPaging
    {
        // Data passed into this function must be ordered else SQL Server will throw an exception
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroToStart, int pageSize)
        {
            if (pageSize == 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "pageSize cannot be zero");

            if (pageNumZeroToStart != 0)
                query = query
                    .Skip(pageNumZeroToStart * pageSize); // skip the correct number of pages

            return query.Take(pageSize); // Takes the number for this pageSize
        }
    }
}
