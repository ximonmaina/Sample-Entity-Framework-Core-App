using MyFirstEfCoreApp.Services.BookServices.QueryObjects;
using System.ComponentModel.DataAnnotations;

namespace MyFirstEfCoreApp.ServiceLayer.BookServices.QueryObjects
{
    public enum BooksFilterBy
    {
        [Display(Name = "All")] NoFilter = 0,
        [Display(Name = "By Votes...")] ByVotes,
        [Display(Name = "By Tags...")] ByTags,
        [Display(Name = "By Year Published...")] ByPublicateYear
    }

    public static class BooksListDtoFilter
    {
        public const string AllBooksNotPublishedString = "Coming Soon";

        /// <summary>
        ///     This method is given both the type of filter and the user-selected filter value
        /// </summary>
        /// <param name="books"></param>
        /// <param name="filterBy"></param>
        /// <param name="filterValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IQueryable<BookListDto> FilterBooksBy(this IQueryable<BookListDto> books, BooksFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return books;

            switch(filterBy)
            {
                case BooksFilterBy.NoFilter:
                    return books;
                case BooksFilterBy.ByVotes:
                    var filterVote = int.Parse(filterValue);
                    return books.Where(x => x.ReviewsAverageVotes > filterVote);
                case BooksFilterBy.ByTags:
                    return books.Where(x => x.TagStrings.Any(t => t == filterValue));
                case BooksFilterBy.ByPublicateYear:
                    if (filterValue == AllBooksNotPublishedString)
                        return books.Where(x => x.PublishedOn > DateTime.UtcNow);

                    var filterYear = int.Parse(filterValue);
                    return books.Where(x => x.PublishedOn.Year == filterYear && x.PublishedOn <= DateTime.UtcNow);
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
