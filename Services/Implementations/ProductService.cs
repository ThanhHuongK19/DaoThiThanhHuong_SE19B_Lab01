using BusinessObjects.Models;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iProductRepository;

        public ProductService()
        {
            iProductRepository = new ProductRepository();
        }

        public List<Product> GetProducts() => iProductRepository.GetProducts();
        public Product GetProductById(int id) => iProductRepository.GetProductById(id);
        public void SaveProduct(Product p) => iProductRepository.SaveProduct(p);
        public void UpdateProduct(Product p) => iProductRepository.UpdateProduct(p);
        public void DeleteProduct(Product p) => iProductRepository.DeleteProduct(p);
    }
}
