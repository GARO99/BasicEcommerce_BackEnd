using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util.Request;

namespace BasicEcommerce_BackEnd.Contracts
{
    public interface IProductService
    {
        ICollection<Product> GetAll();
        Product GetById(long id);
        Product Create(ProductRequest productRequest);
        Product Update(ProductRequest productRequest);
        void Delete(long id);
    }
}
