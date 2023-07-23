using Microsoft.EntityFrameworkCore;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp.ServiceLayer.AdminServices.Concrete
{
    public interface IChangePriceOfferService
    {     

        Book AddUpdatePriceOffer(PriceOffer promotion);
        PriceOffer GetOriginal(int id);
    }

    public class ChangePriceOfferService : IChangePriceOfferService
    {
        private readonly ApplicationDbContext _context;

        public Book OrgBook { get; private set; }

        public ChangePriceOfferService(ApplicationDbContext context)
        {
            _context = context;
        }

        public PriceOffer GetOriginal(int id)
        {
            OrgBook = _context.Books
                .Include(b => b.Promotion)
                .Single(b => b.BookId == id);

            return OrgBook?.Promotion ?? new PriceOffer
            {
                BookId = id,
                NewPrice = OrgBook.Price
            };
        }

        public Book AddUpdatePriceOffer(PriceOffer promotion)
        {
            var book = _context.Books
                .Include(r => r.Promotion)
                .Single(k => k.BookId == promotion.BookId);

            if (book.Promotion == null)
            {
                book.Promotion = promotion;
            }
            else
            {
                book.Promotion.NewPrice = promotion.NewPrice;
                book.Promotion.PromotionalText = promotion.PromotionalText;
            }

            _context.SaveChanges();

            return book;
        }
    }
}
