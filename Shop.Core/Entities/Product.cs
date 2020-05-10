namespace Shop.Core.Entities
{
    public class Product : BaseEntity
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string PictureUrl { get; set; }
        public string Author { get; set; }
    }
}