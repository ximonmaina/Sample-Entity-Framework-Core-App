using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp.ServiceLayer.AdminServices.Concrete
{
    public class AddReviewService
    {
        private readonly ApplicationDbContext _context;
        public string BookTitle { get; private set; }

        public AddReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Review GetBlankReview(int id)
        {
            BookTitle = _context.Books
                .Where(p => p.BookId == id)
                .Select(p => p.Title)
                .Single();

            return new Review
            {
                BookId = id
            };
        }

        public Book AddReviewToBook(Review review)
        {
            var book = _context.Books
                .Include(r => r.Reviews)
                .Single(k => k.BookId == review.BookId);

            book.Reviews.Add(review);
            _context.SaveChanges();
            return book;
        }

    }
}
