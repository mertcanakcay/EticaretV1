using EticaretV1.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Model.Option
{
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3,
        Company = 5
    }

    public class AppUser:CoreEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Like> Likes { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<TreeComment> TreeComment { get; set; }
        public virtual List<DisLike> DisLikes { get; set; }

    }
}
