using BP.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.RepositoryInterfaces
{
    public interface IBussinesLogicRepository
    {
        public Task<Order> CreateOrder(Order order);
        public Task<Order> AddProductOrder(OrderProduct orderProduct);
        public Task<Order> RemoveOrderProducts(Guid idProduct);
        public Task<Order> UpdateProductQuantityOrder(int quantity, Guid productId);
        public Task<Order> ViewOrder(Guid id);
        public Task<Order> PayOrder(Guid id);
    }
}
