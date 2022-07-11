using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.Entities
{
    public class DeliveryMethod
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
