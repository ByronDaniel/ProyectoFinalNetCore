using AutoMapper;
using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.Services
{
    public class BussinessLogicService : IBussinessLogicService
    {
        private readonly IBussinesLogicRepository repository;
        private readonly IMapper mapper;

        public BussinessLogicService(IBussinesLogicRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<OrderDto> AddProductOrder(OrderProductCreateDto createOrderProduct)
        {
            OrderProduct orderProduct = mapper.Map<OrderProduct>(createOrderProduct);
            return mapper.Map<OrderDto> (await repository.AddProductOrder(orderProduct));
        }

        public async Task<OrderDto> CreateOrder(OrderCreateDto orderCreateDto)
        {
            Order order = mapper.Map<Order>(orderCreateDto);
            return  mapper.Map<OrderDto>(await repository.CreateOrder(order));
            
        }

        public async Task<OrderDto> PayOrder(Guid id)
        {
            return mapper.Map<OrderDto>(await repository.PayOrder(id));
        }

        public async Task<OrderDto> RemoveOrderProducts(Guid idProduct)
        {
            return mapper.Map<OrderDto>(await repository.RemoveOrderProducts(idProduct));
        }

        public async Task<OrderDto> UpdateProductQuantityOrder(int quantity, Guid productId)
        {
            return mapper.Map<OrderDto>(await repository.UpdateProductQuantityOrder(quantity, productId));
        }

        public async Task<OrderDto> ViewOrder(Guid id)
        {
            return mapper.Map<OrderDto>(await repository.ViewOrder(id));
        }
    }
}
