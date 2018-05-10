using EticaretV1.Core.Map;
using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Map.Option
{
   public class DisLikeMap:CoreMap<DisLike>
    {
        public DisLikeMap()
        {
            ToTable("dbo.Dislikes");

            HasKey(c => new { c.AppUserID, c.ProductID });
        }
    }
}
