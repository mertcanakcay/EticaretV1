using EticaretV1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Model.Option
{
   public class TreeComment:CoreEntity
    {
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid CommentID { get; set; }
        public virtual Comment Comment { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
    }
}
