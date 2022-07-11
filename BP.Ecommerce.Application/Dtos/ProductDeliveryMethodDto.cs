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
    public class ProductDeliveryMethodDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int DeliveryTimeDays { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
    }
}
