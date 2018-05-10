using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Member.Models
{
    public class JsonLikeVM
    {
        public string userMessage { get; set; }
        public int Likes { get; set; }
        public bool isSuccess { get; set; }
    }
}