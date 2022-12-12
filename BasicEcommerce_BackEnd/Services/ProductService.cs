using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util.Exceptions;
using BasicEcommerce_BackEnd.Util.Request;

namespace BasicEcommerce_BackEnd.Services
{
    public class ProductService : IProductService
    {
        private readonly BasicEcommerceContext DbContext;

        public ProductService(BasicEcommerceContext dbContex)
        {
            DbContext = dbContex;
        }

        public Product Create(ProductRequest productRequest)
        {
            Product product = new()
            {
                ProductName = productRequest.ProductName,
                Price = productRequest.Price
            };
            this.DbContext.Products.Add(product);
            this.DbContext.SaveChanges();

            return this.DbContext.Products.First(p => p.IdProduct == this.DbContext.Products.Max(p => p.IdProduct));
        }

        public void Delete(int id)
        {
            Product? product = this.DbContext.Products.FirstOrDefault(p => p.IdProduct == id);
            if (product == null)
            {
                throw new ConflictException("Product not exist");
            }
            this.DbContext.Products.Remove(product);
            this.DbContext.SaveChanges();
        }

        public ICollection<Product> GetAll()
        {
            return this.DbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            Product? product = this.DbContext.Products.FirstOrDefault(p => p.IdProduct == id);
            if (product == null)
            {
                throw new ConflictException("Product not exist");
            }

            return product;
        }

        public Product Update(ProductRequest productRequest)
        {
            Product? product = this.DbContext.Products.FirstOrDefault(p => p.IdProduct == productRequest.IdProduct);
            if (product == null)
            {
                throw new ConflictException("Product not exist");
            }
            product.ProductName = productRequest.ProductName;
            product.Price = productRequest.Price;

            this.DbContext.SaveChanges();

            return product;
        }
    }
}
