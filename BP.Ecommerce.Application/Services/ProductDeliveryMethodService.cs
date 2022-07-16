using AutoMapper;
using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.Ecommerce.Application.Services
{
    public class ProductDeliveryMethodService : IProductDeliveryMethodService
    {
        private readonly IProductDeliveryMethodRepository _repository;
        private readonly IMapper _mapper;

        public ProductDeliveryMethodService(IProductDeliveryMethodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDeliveryMethodDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            var query = await _repository.GetQueryable(search, limit, offset, sort, order);
            return await query.Select(p => new ProductDeliveryMethodDto
            {
                Id = p.Id,
                DeliveryTimeDays = p.DeliveryTimeDays,
                Price = p.Price,
                ProductId = p.ProductId.ToString(),
                Product = p.Product.Name,
                DeliveryMethodId = p.DeliveryMethodId.ToString(),
                DeliveryMethod = p.DeliveryMethod.Name
            }).ToListAsync();
        }

        public async Task<ProductDeliveryMethodDto> GetByIdAsync(int id)
        {
            var query = await _repository.GetQueryableByIdAsync(id);
            return await query.Select(p => new ProductDeliveryMethodDto
            {
                Id = p.Id,
                DeliveryTimeDays = p.DeliveryTimeDays,
                Price = p.Price,
                ProductId = p.ProductId.ToString(),
                Product = p.Product.Name,
                DeliveryMethodId = p.DeliveryMethodId.ToString(),
                DeliveryMethod = p.DeliveryMethod.Name
            }).SingleOrDefaultAsync();
        }

        public async Task<ProductDeliveryMethodDto> PostAsync(ProductDeliveryMethodDto productDeliveryMethodDto)
        {
            var query = await _repository.PostAsync(_mapper.Map<ProductDeliveryMethod>(productDeliveryMethodDto));
            return await query.Select(p => new ProductDeliveryMethodDto
            {
                Id = p.Id,
                DeliveryTimeDays = p.DeliveryTimeDays,
                Price = p.Price,
                ProductId = p.ProductId.ToString(),
                Product = p.Product.Name,
                DeliveryMethodId = p.DeliveryMethodId.ToString(),
                DeliveryMethod = p.DeliveryMethod.Name
            }).SingleOrDefaultAsync();
        }

        public async Task<ProductDeliveryMethodDto> PutAsync(ProductDeliveryMethodDto productDeliveryMethodDto)
        {
            var query = await _repository.PutAsync(_mapper.Map<ProductDeliveryMethod>(productDeliveryMethodDto));
            return await query.Select(p => new ProductDeliveryMethodDto
            {
                Id = p.Id,
                DeliveryTimeDays = p.DeliveryTimeDays,
                Price = p.Price,
                ProductId = p.ProductId.ToString(),
                Product = p.Product.Name,
                DeliveryMethodId = p.DeliveryMethodId.ToString(),
                DeliveryMethod = p.DeliveryMethod.Name
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
