using EticaretV1.Core.Map;
using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Map.Option
{
   public class ImagesForProductsMap:CoreMap<ImagesForProducts>
    {
        public ImagesForProductsMap()
        {
            ToTable("dbo.ImagesForProducts");

            Property(x => x.ImagePath).IsRequired();

            HasRequired(x => x.Product)
                .WithMany(x => x.ImagesForProducts)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(true);
        }
    }
}
