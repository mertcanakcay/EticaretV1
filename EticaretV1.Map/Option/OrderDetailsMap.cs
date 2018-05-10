using EticaretV1.Core.Map;
using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Map.Option
{
   public class OrderDetailsMap:CoreMap<OrderDetails>
    {
        public OrderDetailsMap()
        {
            ToTable("dbo.OrderDetails");
            Property(x => x.UnitPrice).IsOptional();
            Property(x => x.Quantity).IsOptional();


            HasRequired(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(true);

            HasRequired(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderID)
                .WillCascadeOnDelete(true);
        }
    }
}
