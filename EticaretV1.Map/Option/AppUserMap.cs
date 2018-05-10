using EticaretV1.Core.Map;
using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Map.Option
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");
            Property(x => x.Address).HasMaxLength(150).IsOptional();
            Property(x => x.BirthDate).HasColumnType("datetime2").IsOptional();
            Property(x => x.Email).HasMaxLength(90).IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Role).IsOptional();
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.LastName).HasMaxLength(50).IsOptional();

            HasMany(x => x.Products)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(true);

            HasMany(x => x.Comments)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(true);

            HasMany(x => x.Likes)
               .WithRequired(x => x.AppUser)
               .HasForeignKey(x => x.AppUserID)
               .WillCascadeOnDelete(false);

            HasMany(x => x.Orders)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.TreeComment)
                .WithRequired(x => x.AppUser)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(true);

            HasMany(x => x.DisLikes)
              .WithRequired(x => x.AppUser)
              .HasForeignKey(x => x.AppUserID)
              .WillCascadeOnDelete(false);
          
        }
    }
}
