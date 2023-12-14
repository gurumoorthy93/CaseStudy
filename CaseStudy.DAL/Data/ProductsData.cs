using CaseStudy.Core.Models;

namespace CaseStudy.DAL.Data
{
    public class ProductsData
    {
        public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel()
            {
                Id = 1,
                Name = "Puzzle",
                Description = "Puzzle for Children above 5 Years",
                Category = "Toys",
                Image = "/PuzzleImage",
                Price = 350,
                Quantity = 10
            },
            new ProductModel()
            {
                Id = 2,
                Name = "Dress",
                Description = "Jeans",
                Category = "Clothing",
                Image = "/JeansImage",
                Price = 1200,
                Quantity = 9
            },
            new ProductModel()
            {
                Id = 3,
                Name = "Keyboard",
                Description = "Qwerty Keyboard",
                Category = "Computer & Accessories",
                Image = "/KeyboardImage",
                Price = 1500,
                Quantity = 35
            },
            new ProductModel()
            {
                Id = 4,
                Name = "Mouse",
                Description = "Logitech Mouse",
                Category = "Computer & Accessories",
                Image = "/MouseImage",
                Price = 700,
                Quantity = 12
            }
        };
    }
}
