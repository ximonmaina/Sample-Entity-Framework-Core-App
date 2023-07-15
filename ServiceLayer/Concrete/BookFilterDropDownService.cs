using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.ServiceLayer.BookServices;
using MyFirstEfCoreApp.ServiceLayer.BookServices.QueryObjects;

namespace MyFirstEfCoreApp.ServiceLayer.Concrete
{
    public interface IBookFilterDropDownService
    {
        IEnumerable<DropdownTuple> GetFilterDropDownValues(BooksFilterBy filterBy);
    }

    public class BookFilterDropDownService : IBookFilterDropDownService
    {

        private readonly ApplicationDbContext _db;

        public BookFilterDropDownService(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// This makes the various Value + text to go in the dropdown based in the FilterBy option
        /// </summary>
        /// <param name="filterBy"></param>
        /// <returns></returns>
        public IEnumerable<DropdownTuple> GetFilterDropDownValues(BooksFilterBy filterBy)
        {
            switch (filterBy)
            {
                case BooksFilterBy.NoFilter:
                    return new List<DropdownTuple>();
                case BooksFilterBy.ByVotes:
                    return FormVotesDropDown();
                case BooksFilterBy.ByTags:
                    return _db.Tags
                        .Select(x => new DropdownTuple
                        {
                            Value = x.TagId,
                            Text = x.TagId
                        }).ToList();
                case BooksFilterBy.ByPublicateYear:
                    var result = _db.Books
                        .Where(x => x.PublishedOn <= DateTime.Today)
                        .Select(x => x.PublishedOn.Year)
                        .Distinct()
                        .OrderByDescending(x => x)
                        .Select(x => new DropdownTuple
                        {
                            Value = x.ToString(),
                            Text = x.ToString()
                        }).ToList();
                    var comingSoon = _db.Books
                        .Any(x => x.PublishedOn > DateTime.Today);
                    if (comingSoon)
                        result.Insert(0, new DropdownTuple
                        {
                            Value = BooksListDtoFilter.AllBooksNotPublishedString,
                            Text = BooksListDtoFilter.AllBooksNotPublishedString
                        });

                    return result;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }

        // private methods
        private static IEnumerable<DropdownTuple> FormVotesDropDown()
        {
            return new[]
            {
                new DropdownTuple {Value = "4", Text = "4 stars and up"},
                new DropdownTuple {Value = "3", Text = "3 stars and up"},
                new DropdownTuple {Value = "2", Text = "2 stars and up"},
                new DropdownTuple {Value = "1", Text = "1 star and up"},
            };
        }
    }
}
