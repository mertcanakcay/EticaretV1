using EticaretV1.Core.Map;
using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Map.Option
{
   public class CommentMap:CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("dbo.Comments");
            Property(x => x.Content).HasMaxLength(50).IsOptional();
            Property(x => x.Header).IsRequired();

            HasRequired(x => x.Product)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ProductID)
                .WillCascadeOnDelete(false);


            HasMany(x => x.TreeComment)
                .WithRequired(x => x.Comment)
                .HasForeignKey(x => x.CommentID)
                .WillCascadeOnDelete(false);
           
            HasRequired(x => x.AppUser)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.AppUserID)
               .WillCascadeOnDelete(true);
        }
    }
}
