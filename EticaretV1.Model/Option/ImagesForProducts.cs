using EticaretV1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Model.Option
{
   public class ImagesForProducts:CoreEntity
    {
        public string ImagePath { get; set; }
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
