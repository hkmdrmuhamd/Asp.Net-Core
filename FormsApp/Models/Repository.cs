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
            _products.Add(new Product { ProductId = 2, Name = "Iphone 11", Price = 29000, Image = "2.jpg", IsActive = false, CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, Name = "Iphone 13", Price = 39000, Image = "3.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product { ProductId = 4, Name = "Iphone 12", Price = 33000, Image = "4.jpg", IsActive = false, CategoryId = 1 });

            _products.Add(new Product { ProductId = 5, Name = "MacBook Air M1", Price = 69900, Image = "5.jpg", IsActive = false, CategoryId = 2 });
            _products.Add(new Product { ProductId = 6, Name = "MacBook Air M2", Price = 78999, Image = "6.jpg", IsActive = true, CategoryId = 2 });
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static void CreateProduct(Product model)
        {
            _products.Add(model);
        }

        public static void EditProduct(Product updateProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updateProduct.ProductId);

            if (entity != null)
            {
                entity.Name = updateProduct.Name;
                entity.Price = updateProduct.Price;
                entity.CategoryId = updateProduct.CategoryId;
                entity.IsActive = updateProduct.IsActive;
                entity.Image = updateProduct.Image;
            }
        }

        public static void EditIsActive(Product updateProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updateProduct.ProductId);

            if (entity != null)
            {
                entity.IsActive = updateProduct.IsActive;
            }
        }

        public static void DeleteProduct(Product product)
        {
            var entity = _products.FirstOrDefault(product => product.ProductId == product.ProductId);
            if(entity != null)
            {
                _products.Remove(entity);
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