using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util.Request;

namespace BasicEcommerce_BackEnd.Contracts
{
    public interface IOrderService
    {
        ICollection<Order> GetAll();
        Order GetById(long id);
        Order Create(OrderRequest orderRequest);
    }
}
