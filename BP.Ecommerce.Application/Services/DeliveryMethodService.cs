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
    public class DeliveryMethodService : IDeliveryMethodService
    {
        private readonly IDeliveryMethodRepository _repository;
        private readonly IMapper _mapper;

        public DeliveryMethodService(IDeliveryMethodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DeliveryMethodDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            return _mapper.Map<List<DeliveryMethodDto>>(await _repository.GetAllAsync(search, limit, offset, sort, order));
        }

        public async Task<DeliveryMethodDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<DeliveryMethodDto>(await _repository.GetByIdAsync(id));
        }

        public async Task<DeliveryMethodDto> PostAsync(DeliveryMethodDto deliveryMethodDto)
        {
            return _mapper.Map<DeliveryMethodDto>(await _repository.PostAsync(
                _mapper.Map<DeliveryMethod>(deliveryMethodDto)
                ));
        }

        public async Task<DeliveryMethodDto> PutAsync(DeliveryMethodDto deliveryMethodDto)
        {
            return _mapper.Map<DeliveryMethodDto>(await _repository.PutAsync(
                _mapper.Map<DeliveryMethod>(deliveryMethodDto)
                ));
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
