namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository(){
            _categories.Add(new Category { CategoryId = 1, Name = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, Name = "Bilgisayar" });
            
            _products.Add(new Product { ProductId = 1, Name = "Iphone 14", Price = 47300, Image = "1.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "Iphone 11", Price = 29000, Image = "2.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, Name = "Iphone 13", Price = 39000, Image = "3.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 4, Name = "Iphone 12", Price = 33000, Image = "4.jpg", IsActive = true, CategoryId = 1 });

            _products.Add(new Product { ProductId = 5, Name = "MacBook Air M1", Price = 69900, Image = "5.jpg", IsActive = true, CategoryId = 2 });
            _products.Add(new Product { ProductId = 6       , Name = "MacBook Air M2", Price = 78999, Image = "6.jpg", IsActive = true, CategoryId = 2 });
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}