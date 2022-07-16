using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid DeliveryMethodId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalPrice { get; set; }
        public bool ValuePaid { get; set; } = false;
    }
}
