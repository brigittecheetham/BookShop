namespace BookShop.Api.Dtos
{
    public class BookToReturnDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string PictureUrl { get; set; }
    }
}