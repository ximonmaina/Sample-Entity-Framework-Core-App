using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp.ServiceLayer.AdminServices.Concrete
{
    public interface IChangePubDateService
    {
        ChangePubDateDto GetOriginal(int id);
        Book UpdateBook(ChangePubDateDto dto);
    }

    public class ChangePubDateService : IChangePubDateService
    {
        private readonly ApplicationDbContext _context;

        public ChangePubDateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ChangePubDateDto GetOriginal(int id)
        {
            return _context.Books
                .Select(b => new ChangePubDateDto
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    PublishedOn = b.PublishedOn
                })
                .Single(x => x.BookId == id);
        }
        
        public Book UpdateBook(ChangePubDateDto dto)
        {
            var book = _context.Books.SingleOrDefault(book => book.BookId == dto.BookId);

            if (book is null)
                throw new ArgumentException("Book not found");

            book.PublishedOn = dto.PublishedOn;
            _context.SaveChanges();
            return book;
        }
    }
}
