using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DeliveryMethodId { get; set; }

        [ForeignKey("DeliveryMethodId")]
        public DeliveryMethod DeliveryMethod { get; set; }

        public decimal Subtotal { get; set; }
        public decimal TotalPrice { get; set; }
        public bool ValuePaid { get; set; } = false;
    }
}
