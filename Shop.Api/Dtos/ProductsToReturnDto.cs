namespace Shop.Api.Dtos
{
    public class ProductsToReturnDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string PictureUrl { get; set; }
    }
}