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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BrandDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            return _mapper.Map<List<BrandDto>>(await _repository.GetAllAsync(search, limit, offset, sort, order));
        }

        public async Task<BrandDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<BrandDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<BrandDto> PostAsync(BrandDto brandDto)
        {
            return _mapper.Map<BrandDto>(await _repository.PostAsync(
                _mapper.Map<Brand>(brandDto)
                ));
        }

        public async Task<BrandDto> PutAsync(BrandDto brandDto)
        {
            return _mapper.Map<BrandDto>(await _repository.PutAsync(
                _mapper.Map<Brand>(brandDto)
                ));
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
