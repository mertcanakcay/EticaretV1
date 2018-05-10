using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Admin.Models
{
    public class AppUserDTO
    {
        public Role Role { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

    }
}