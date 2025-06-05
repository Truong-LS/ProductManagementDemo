using BusinessObjects;
using Repositories_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iproductRepository;
        public ProductService(IProductRepository productRepository)
        {
            iproductRepository = productRepository;
        }
        public void DeleteProduct(Product p)
        {
            iproductRepository.DeleteProduct(p);
        }
        public Product GetProductById(int id)
        {
            return iproductRepository.GetProductById(id);
        }
        public List<Product> GetProducts()
        {
            return iproductRepository.GetProducts();
        }
        public void SaveProduct(Product p)
        {
            iproductRepository.SaveProduct(p);
        }
        public void UpdateProduct(Product p)
        {
            iproductRepository.updateProduct(p);
        }
}
