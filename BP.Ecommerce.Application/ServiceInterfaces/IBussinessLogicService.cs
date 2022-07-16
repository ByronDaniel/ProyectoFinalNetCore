using BP.Ecommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.Services
{
    public interface IBussinessLogicService
    {
        public Task<OrderDto> CreateOrder(OrderCreateDto orderCreateDto);
        public Task<OrderDto> AddProductOrder(OrderProductCreateDto createOrderProduct);
        public Task<OrderDto> RemoveOrderProducts(Guid idProduct);
        public Task<OrderDto> UpdateProductQuantityOrder(int quantity, Guid productId);
        public Task<OrderDto> ViewOrder(Guid id);
        public Task<OrderDto> PayOrder(Guid id);
    }
}
