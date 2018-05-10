using EticaretV1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Model.Option
{
   public class Order:CoreEntity
    {
        public DateTime? OrderDate { get; set; }
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
