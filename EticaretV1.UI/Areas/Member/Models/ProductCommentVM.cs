using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Member.Models
{
    public class ProductCommentVM
    {
        public ProductCommentVM()
        {
            Comments = new List<Comment>();
        }

        public Product Product { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public int Likes { get; set; }

        public List<ImagesForProducts> ImagesForProducts { get; set; }

    }
}