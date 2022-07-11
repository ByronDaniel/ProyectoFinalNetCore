using BP.Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool Availability { get; set; } = true;
        public string ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
