using EticaretV1.Core.Map;
using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Map.Option
{
   public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbp.Products");
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.UnitsInStock).IsRequired();
            Property(x => x.ImagePath).HasColumnName("FotoYolu").IsOptional();
            Property(x => x.Quantity).IsOptional();

            HasMany(x => x.Comments)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser)
              .WithMany(x => x.Products)
              .HasForeignKey(x => x.AppUserID)
              .WillCascadeOnDelete(true);

            HasMany(x => x.Likes)
               .WithRequired(x => x.Product)
               .HasForeignKey(x => x.ProductID)
               .WillCascadeOnDelete(true);

            HasMany(x => x.OrderDetails)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(true);

            HasMany(x => x.ImagesForProducts)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(true);

            HasMany(x => x.DisLikes)
            .WithRequired(x => x.Product)
            .HasForeignKey(x => x.ProductID)
            .WillCascadeOnDelete(false);

        }
    }
}
