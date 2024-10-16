using Data.Entities;
using Data.Repository;


public class ProductService
{
    private readonly ProductRepository _productRepository;
    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Product CreateProduct(Product newProduct)
    {
        return _productRepository.CreateProduct(newProduct);
    }

    public IEnumerable<Product> ReadProducts()
    {
        return _productRepository.ReadProduct();
    }

    public Product ReadProducts(int id)
    {
        return _productRepository.ReadProductById(id);
    }

    // Update method pending  @Pablo

    public void DeleteProductById(int id)
    {
        _productRepository.DeleteProductById(id);
    }

    public List<Product> FilterAvailableProducts(List<int> productsIds)

    {
        List<Product> products = new List<Product>();
        foreach (int productId in productsIds)
        {
            Product? productToCheck = _productRepository.ReadProductById(productId);
            //Chequear si es activo
            //Chequerar el stock
            if (productToCheck is not null &&
                productToCheck.State == Data.Models.StateEnum.Active &&
                productToCheck.Stock > 0)
            {
                //Lo instanciamos y agregamos a la lista de retorno
                products.Add(productToCheck);
            }
        }
        return products;
    }


}