using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Application.Dtos
{
    public class OrderProductCreateDto
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int QuantityProduct { get; set; } = 1;
    }
}
