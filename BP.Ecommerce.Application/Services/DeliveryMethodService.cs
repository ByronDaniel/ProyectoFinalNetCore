using AutoMapper;
using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServiceInterfaces;
using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;

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
            List<DeliveryMethod> deliveryMethods = await _repository.GetAllAsync(search, limit, offset, sort, order);
            List<DeliveryMethodDto> deliveryMethodDtos = _mapper.Map<List<DeliveryMethodDto>>(deliveryMethods);
            return deliveryMethodDtos;
        }

        public async Task<DeliveryMethodDto> GetByIdAsync(Guid id)
        {
            DeliveryMethod deliveryMethod = await _repository.GetByIdAsync(id);
            DeliveryMethodDto deliveryMethodDto = _mapper.Map<DeliveryMethodDto>(deliveryMethod);
            return deliveryMethodDto;
        }

        public async Task<DeliveryMethodDto> PostAsync(CreateDeliveryMethodDto createDeliveryMethodDto)
        {
            DeliveryMethod deliveryMethod = _mapper.Map<DeliveryMethod>(createDeliveryMethodDto);
            DeliveryMethod deliveryMethodResult = await _repository.PostAsync(deliveryMethod);
            DeliveryMethodDto deliveryMethodDto = _mapper.Map<DeliveryMethodDto>(deliveryMethodResult);
            return deliveryMethodDto;
        }

        public async Task<DeliveryMethodDto> PutAsync(DeliveryMethodDto updateDeliveryMethodDto)
        {
            DeliveryMethod deliveryMethod = _mapper.Map<DeliveryMethod>(updateDeliveryMethodDto);
            DeliveryMethod deliveryMethodResult = await _repository.PutAsync(deliveryMethod);
            DeliveryMethodDto deliveryMethodDto = _mapper.Map<DeliveryMethodDto>(deliveryMethodResult);
            return deliveryMethodDto;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}
