using BP.Ecommerce.Application.ServiceInterfaces;
using BP.Ecommerce.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication( this IServiceCollection services, IConfiguration configuration )
        {
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDeliveryMethodService, ProductDeliveryMethodService>();
            return services;
        }
    }
}
