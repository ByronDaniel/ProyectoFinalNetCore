using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Ecommerce.Domain.Entities.Base
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool Status { get; set; } = true;
    }
}
