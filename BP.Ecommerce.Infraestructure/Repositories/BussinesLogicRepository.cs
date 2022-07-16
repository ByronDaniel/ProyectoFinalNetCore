using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;
using BP.Ecommerce.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Infraestructure.Repositories
{
    public class BussinesLogicRepository : IBussinesLogicRepository
    {
        private readonly EcommerceDbContext context;

        public BussinesLogicRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> AddProductOrder(OrderProduct orderProduct)
        {
            await context.OrderProducts.AddAsync(orderProduct);
            await context.SaveChangesAsync();
            return orderProduct.Order;
        }

        public async Task<Order> RemoveOrderProducts(Guid idProduct)
        {
            OrderProduct orderProduct = await context.OrderProducts.FindAsync(idProduct);
            context.OrderProducts.Remove(orderProduct);
            await context.SaveChangesAsync();
            return orderProduct.Order;
        }


        public async Task<Order> UpdateProductQuantityOrder(int quantity, Guid productId)
        {
            OrderProduct orderProduct = await context.OrderProducts.Where(o => o.ProductId == productId).SingleOrDefaultAsync();
            orderProduct.QuantityProduct = quantity;
            context.Entry(orderProduct).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return orderProduct.Order;
        }

        public async Task<Order> ViewOrder(Guid id)
        {
            return await context.Orders.FindAsync(id);
        }
   
        public async Task<Order> PayOrder(Guid id)
        {
            Order order = await context.Orders.FindAsync(id);
            order.ValuePaid = true;

            context.Entry(order).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return order;
        }
    }
}
