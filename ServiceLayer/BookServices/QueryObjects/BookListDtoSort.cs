using MyFirstEfCoreApp.Services.BookServices.QueryObjects;
using System.ComponentModel.DataAnnotations;

namespace MyFirstEfCoreApp.ServiceLayer.BookServices.QueryObjects
{
    public enum OrderByOptions
    {
        [Display(Name = "sort by...")] SimpleOrder = 0,
        [Display(Name = "Votes ↑")] ByVotes,
        [Display(Name = "PublicationDate ↑")] ByPublicationDate,
        [Display(Name = "Price ↓")] ByPriceLowestFirst,
        [Display(Name = "Price ↑")] ByPriceHighestFirst
    }

    public static class BookListDtoSort
    {
       

        public static IQueryable<BookListDto>  OrderBooksBy(this IQueryable<BookListDto> books, OrderByOptions orderByOptions)
        {
            switch(orderByOptions)
            {
                case OrderByOptions.SimpleOrder: //#A
                    return books.OrderByDescending( //#A
                        x => x.BookId);                    
                case OrderByOptions.ByVotes: //#B
                    return books.OrderByDescending(x => x.ReviewsAverageVotes ?? 0); //#B
                case OrderByOptions.ByPublicationDate: //#C
                    return books.OrderByDescending(x => x.PublishedOn); //#C
                case OrderByOptions.ByPriceLowestFirst: //#D
                    return books.OrderByDescending(x => x.ActualPrice); //#D
                case OrderByOptions.ByPriceHighestFirst: //#D
                    return books.OrderByDescending(x => x.Price); //#D
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }

        //#A Show latest entries first
        //#B Order books by votes. Books without any votes(null) go to the bottom
        //#C Latest books first
        //#D Order by actual price, which takes into account any promotional price - both lowest first and highest first
    }
}
