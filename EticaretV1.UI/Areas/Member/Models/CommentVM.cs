using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Member.Models
{
    public class CommentVM
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}