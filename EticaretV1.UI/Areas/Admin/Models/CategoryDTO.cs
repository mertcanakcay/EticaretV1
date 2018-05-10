using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Admin.Models
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}