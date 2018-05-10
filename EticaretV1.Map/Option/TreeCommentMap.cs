using EticaretV1.Core.Map;
using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Map.Option
{
   public class TreeCommentMap:CoreMap<TreeComment>
    {
        public TreeCommentMap()
        {
            ToTable("dbo.TreeComments");
            Property(x => x.Content).HasMaxLength(255).IsRequired();
            Property(x => x.Header).HasMaxLength(100).IsRequired();

            HasRequired(x => x.AppUser)
                .WithMany(x => x.TreeComment)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(true);

            HasRequired(x => x.Comment)
               .WithMany(x => x.TreeComment)
               .HasForeignKey(x => x.CommentID)
               .WillCascadeOnDelete(false);
        }
    }
}
