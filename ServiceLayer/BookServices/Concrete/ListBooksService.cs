using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.ServiceLayer.BookServices.QueryObjects;
using MyFirstEfCoreApp.Services.BookServices.QueryObjects;

namespace MyFirstEfCoreApp.ServiceLayer.BookServices.Concrete
{
    public class ListBooksService
    {
        private readonly ApplicationDbContext _db;

        public ListBooksService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// This method combines all the Query Objects to create a complex query
        /// including select, sort, filter, and page
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public IQueryable<BookListDto> SortFilterPage(SortFilterPageOptions options)
        {
            var booksQuery = _db.Books
                .AsNoTracking()
                .MapBookToDto()
                .OrderBooksBy(options.OrderByOptions)
                .FilterBooksBy(options.FilterBy, options.FilterValue);

            // This stage setups up the number of pages and makes sure the PageNum is in the right range
            options.SetupRestOfDto(booksQuery);

            return booksQuery.Page(options.PageNum - 1, options.PageSize);

        }
    }
}
