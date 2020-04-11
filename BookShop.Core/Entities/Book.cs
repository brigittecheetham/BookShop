namespace BookShop.Core.Entities
{
    public class Book : BaseEntity
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public string PictureUrl { get; set; }
        public string Author { get; set; }
    }
}