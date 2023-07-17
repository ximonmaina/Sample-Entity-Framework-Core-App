using MyFirstEfCoreApp.ServiceLayer.BookServices.QueryObjects;

namespace MyFirstEfCoreApp.ServiceLayer.BookServices
{
    public class SortFilterPageOptions
    {
        public const int defaultPageSize = 10;

        //-----------------------------------
        //Paging parts 
        private int _pageNum = 1;
        private int _pageSize = defaultPageSize;

        /// <summary>
        /// This holds the possible page sizes
        /// </summary>
        public int[] PageSizes = new[] { 5, defaultPageSize, 20, 50, 100, 500, 1000 };

        public OrderByOptions OrderByOptions { get; set; }

        public BooksFilterBy FilterBy { get; set; }

        public string FilterValue { get; set; }

        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// This is set to the number of pages available based on number of entries in the query
        /// </summary>
        public int NumOfPages { get; private set; }

        /// <summary>
        /// Holds the state of the various SortFilterPage parts
        /// </summary>
        public string PrevStateCheck { get; set; }

        public void SetupRestOfDto<T>(IQueryable<T> query)
        {
            NumOfPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            PageNum = Math.Min(
                Math.Max(1, PageNum), NumOfPages
                );

            var newCheckState = GenerateCheckState();
            if(PrevStateCheck != newCheckState)
            {
                PageNum = 1;
            }

            PrevStateCheck = newCheckState;
        }

        /// <summary>
        ///     This returns a string containing the state of the SortFilterPage data
        ///     that, if they change, should cause the PageNum to be set back to 1
        /// </summary>
        /// <returns></returns>
        private string GenerateCheckState()
        {
            return $"{(int)FilterBy},{FilterValue},{PageSize},{NumOfPages}";
        }

    }
}
