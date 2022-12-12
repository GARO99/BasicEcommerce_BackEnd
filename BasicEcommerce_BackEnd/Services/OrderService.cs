using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util.Exceptions;
using BasicEcommerce_BackEnd.Util.Request;

namespace BasicEcommerce_BackEnd.Services
{
    public class OrderService : IOrderService
    {
        private readonly BasicEcommerceContext DbContext;

        public OrderService(BasicEcommerceContext dbContex)
        {
            DbContext = dbContex;
        }

        public Order Create(OrderRequest orderRequest)
        {
            Order order = new()
            {
                Idclient = orderRequest.Idclient,
                Date = orderRequest.Date,
                TotalAmount = orderRequest.TotalAmount
            };
            this.DbContext.Orders.Add(order);
            this.DbContext.SaveChanges();
            orderRequest.IdOrder = this.DbContext.Orders.Max(o => o.IdOrder);
            foreach (OrderDetailRequest orderDetail in orderRequest.OrderDetails)
            {
                this.DbContext.OrderDetails.Add(new OrderDetail()
                {
                    IdOrder = orderRequest.IdOrder,
                    IdProduct = orderDetail.IdProduct,
                    Quantity = orderDetail.Quantity,
                    Amount = orderDetail.Amount
                });
            }            
            this.DbContext.SaveChanges();

            Order newOrder = this.DbContext.Orders.First(o => o.IdOrder == this.DbContext.Orders.Max(o => o.IdOrder));
            this.DbContext.Entry(newOrder).Reference(o => o.Client).Load();
            this.DbContext.Entry(newOrder).Collection(o => o.OrderDetails).Load();
            this.DbContext.Entry(newOrder.Client).Reference(c => c.Person).Load();
            foreach (OrderDetail orderDetail in newOrder.OrderDetails)
            {
                this.DbContext.Entry(orderDetail).Reference(o => o.Product).Load();
            }

            return newOrder;
        }

        public ICollection<Order> GetAll()
        {
            ICollection <Order> orders = this.DbContext.Orders.ToList();
            foreach (Order order in orders)
            {
                this.DbContext.Entry(order).Reference(o => o.Client).Load();
                this.DbContext.Entry(order).Collection(o => o.OrderDetails).Load();
                this.DbContext.Entry(order.Client).Reference(c => c.Person).Load();
                foreach (OrderDetail orderDetail in order.OrderDetails)
                {
                    this.DbContext.Entry(orderDetail).Reference(o => o.Product).Load();
                }
            }

            return orders;
        }

        public Order GetById(long id)
        {
            Order? order = this.DbContext.Orders.FirstOrDefault(o => o.IdOrder == id);
            if (order == null)
            {
                throw new ConflictException("Order not exist");
            }
            this.DbContext.Entry(order).Reference(o => o.Client).Load();
            this.DbContext.Entry(order).Collection(o => o.OrderDetails).Load();
            this.DbContext.Entry(order.Client).Reference(c => c.Person).Load();
            foreach (OrderDetail orderDetail in order.OrderDetails)
            {
                this.DbContext.Entry(orderDetail).Reference(o => o.Product).Load();
            }

            return order;
        }
    }
}
