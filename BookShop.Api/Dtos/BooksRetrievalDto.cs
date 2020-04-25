namespace BookShop.Api.Dtos
{
    public class BooksRetrievalDto
    {
        public int PageIndex {get;set;}
        public int PageSize {get;set;}
        public int? GenreId { get; set; }
        public string Sort { get; set; }
        public string Search {get;set;}
    }
}