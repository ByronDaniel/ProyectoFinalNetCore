using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.Dtos
{
    public class OrderCreateDto
    {
        public Guid DeliveryMethodId { get; set; }
        public decimal Subtotal { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;
    }
}
