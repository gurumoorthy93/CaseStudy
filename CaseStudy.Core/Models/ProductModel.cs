namespace CaseStudy.Core.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            Category= string.Empty;
            Image= string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
