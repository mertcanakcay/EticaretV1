using EticaretV1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Model.Option
{
   public class OrderDetails:CoreEntity
    {
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
    }
}
