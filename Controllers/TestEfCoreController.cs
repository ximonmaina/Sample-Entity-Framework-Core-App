using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.ServiceLayer.BookServices.QueryObjects;
using MyFirstEfCoreApp.ServiceLayer.Concrete;
using MyFirstEfCoreApp.Services.BookServices.QueryObjects;

namespace MyFirstEfCoreApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestEfCoreController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        private readonly IBookFilterDropDownService bookFilterDropDownService;

        public TestEfCoreController(ApplicationDbContext db, IBookFilterDropDownService bookFilterDropDownService)
        {
            _db = db;
            this.bookFilterDropDownService = bookFilterDropDownService;
        }



        /// <summary>
        /// Select query that includes a non-SQL command, string.Join
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-books-with-default-sorting")]
        public IActionResult  GetBooks()
        {
            var books = _db.Books.MapBookToDto().OrderBooksBy(OrderByOptions.ByVotes);

            return Ok(books);
        }

        [HttpGet("get-book-filter-dropdown-values")]
        public IActionResult GetBookFilterDropDownValues([FromQuery] BooksFilterBy filterBy)
        {
            var dropDownValues = bookFilterDropDownService.GetFilterDropDownValues(filterBy);

            return Ok(dropDownValues);
        }

        [HttpGet("filter-books")]
        public ActionResult<IEnumerable<BookListDto>> GetFilteredBooks([FromQuery] BooksFilterBy filterBy, [FromQuery] string filterValue)
        {
            var filteredBooks = _db.Books
                .MapBookToDto()
                .FilterBooksBy(filterBy, filterValue);

            return Ok(filteredBooks);
        }

    }
}
