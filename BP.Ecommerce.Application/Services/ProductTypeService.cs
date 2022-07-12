using AutoMapper;
using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.Ecommerce.Application.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _repository;
        private readonly IMapper _mapper;

        public ProductTypeService(IProductTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductTypeDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            return _mapper.Map<List<ProductTypeDto>>(await _repository.GetAllAsync(search, limit, offset, sort, order));
        }

        public async Task<ProductTypeDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ProductTypeDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<ProductTypeDto> PostAsync(ProductTypeDto productTypeDto)
        {
            return _mapper.Map<ProductTypeDto>(await _repository.PostAsync(
                _mapper.Map<ProductType>(productTypeDto)
                ));
        }

        public async Task<ProductTypeDto> PutAsync(ProductTypeDto productTypeDto)
        {
            return _mapper.Map<ProductTypeDto>(await _repository.PutAsync(
                _mapper.Map<ProductType>(productTypeDto)
                ));
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
