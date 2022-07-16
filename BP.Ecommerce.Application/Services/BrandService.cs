using AutoMapper;
using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.Exceptions;
using BP.Ecommerce.Application.ServiceInterfaces;
using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IValidator<CreateBrandDto> validator;

        public BrandService(IBrandRepository repository, IMapper mapper, IValidator<CreateBrandDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            this.validator = validator;
        }

        public async Task<List<BrandDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            List<Brand> brands = await _repository.GetAllAsync(search, limit, offset, sort, order);
            List<BrandDto> brandDtos = _mapper.Map<List<BrandDto>>(brands);
            return brandDtos;
        }

        public async Task<BrandDto> GetByIdAsync(Guid id)
        {
            Brand brand = await _repository.GetByIdAsync(id);
            if (brand == null)
            {
                throw new Exception($"No existe marca con id: {id}");
            }
            BrandDto brandDto = _mapper.Map<BrandDto>(brand);
            return brandDto;
        }

        public async Task<BrandDto> PostAsync(CreateBrandDto createBrandDto)
        {
            await validator.ValidateAndThrowAsync(createBrandDto);
            Brand brand = _mapper.Map<Brand>(createBrandDto);
            Brand brandResult = await _repository.PostAsync(brand);
            BrandDto brandDto = _mapper.Map<BrandDto>(brandResult);
            return brandDto;
        }

        public async Task<BrandDto> PutAsync(BrandDto updateBrandDto)
        {
            Brand brand = _mapper.Map<Brand>(updateBrandDto);
            Brand brandResult = await _repository.PutAsync(brand);
            BrandDto brandDto = _mapper.Map<BrandDto>(brandResult);
            return brandDto;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
