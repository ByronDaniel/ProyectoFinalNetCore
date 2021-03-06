using AutoMapper;
using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Domain.Entities;

namespace BP.Ecommerce.API.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, CreateBrandDto>();

            CreateMap<BrandDto, Brand>();
            CreateMap<Brand, BrandDto>();

            CreateMap<DeliveryMethodDto, DeliveryMethod>();
            CreateMap<DeliveryMethod, DeliveryMethodDto>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDeliveryMethodDto, ProductDeliveryMethod>();
            CreateMap<ProductDeliveryMethod, ProductDeliveryMethodDto>();

            CreateMap<ProductTypeDto, ProductType>();
            CreateMap<ProductType, ProductTypeDto>();

            CreateMap<OrderProductCreateDto, OrderProduct> ();
            CreateMap<Order, OrderDto> ();

            CreateMap<OrderCreateDto, Order> ();
            CreateMap<Order, OrderCreateDto> ();

        }
    }
}
