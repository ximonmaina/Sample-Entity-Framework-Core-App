using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Data.Entities;
using MyFirstEfCoreApp.ServiceLayer.AdminServices;
using MyFirstEfCoreApp.ServiceLayer.AdminServices.Concrete;
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
        private readonly IChangePubDateService _changePubDateService;

        public TestEfCoreController(ApplicationDbContext db, IBookFilterDropDownService bookFilterDropDownService, IChangePubDateService changePubDateService)
        {
            _db = db;
            this.bookFilterDropDownService = bookFilterDropDownService;
            _changePubDateService = changePubDateService;
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

        [HttpGet("get-book-to-update-pub-date")]
        public ActionResult<ChangePubDateDto> GetBookToUpdate([FromQuery] int id)
        {
            var bookToUpdate = _changePubDateService.GetOriginal(id);

            return Ok(bookToUpdate);
        }

        [HttpPost("update-book-pub-date")]
        public ActionResult<Book> UpdateBook([FromBody] ChangePubDateDto dto)
        {
            var book = _changePubDateService.UpdateBook(dto);

            return Ok(book);
        }

    }
}
