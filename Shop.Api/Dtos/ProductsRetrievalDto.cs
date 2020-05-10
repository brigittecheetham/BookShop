namespace Shop.Api.Dtos
{
    public class ProductsRetrievalDto
    {
        public int PageIndex {get;set;}
        public int PageSize {get;set;}
        public int? CategoryId { get; set; }
        public string Sort { get; set; }
        public string Search {get;set;}
    }
}