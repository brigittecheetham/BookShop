namespace BookShop.Infrastructure.Data.Specifications
{
    public class BookSpecificationParameters
    {
        private const int MAXPAGESIZE = 50;
        public int PageIndex {get;set;} = 1;

        private int _pageSize = 6;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = value > MAXPAGESIZE ? MAXPAGESIZE : value ;
        }

        public int? GenreId { get; set; }
        public string Sort { get; set; }

        // private string _search;
        // public string Search 
        // {
        //     get => _search;
        //     set => _search = value.ToLower();
        // }

        public string Search { get; set; }
    }
}