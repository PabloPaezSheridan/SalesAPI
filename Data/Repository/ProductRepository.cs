using Data.Entities;
using Data.Models;

namespace Data.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public Product CreateProduct(Product newProduct)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public IEnumerable<Product> ReadProduct()
        {
            return _context.Products.Where(p => p.State == StateEnum.Active);
        }

        public Product? ReadProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id && p.State == StateEnum.Active);
        }

        // Update method pending @Pablo

        public void DeleteProductById(int id)
        {
            _context.Products.Single(p => p.Id == id).State = StateEnum.Deleted;
            _context.SaveChanges();
        }
    }
}
