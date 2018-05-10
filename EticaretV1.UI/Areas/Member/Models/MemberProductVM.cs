using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Member.Models
{
    public class MemberProductVM
    {
        public List<Product> PendingProduct { get; set; }
        public List<Product> ApprovedProduct { get; set; }

        public Guid AppUserID { get; set; }
        public ImagesForProducts ımageForProducts { get; set; }
    }
}