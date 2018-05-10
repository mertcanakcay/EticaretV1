using EticaretV1.Model.Option;
using EticaretV1.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Service.Option
{
   public class AppUserService:ServiceBase<AppUser>
    {

        public bool UyeKontrolu(string userName,string password)
        {
            return Any(x => x.UserName == userName && x.Password == password);
        }

        public AppUser UyeAdındanBul(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }

        public List<AppUser> ListUser()
        {
            return GetDefault(x => x.Role == Role.Admin || x.Role == Role.Member || x.Role == Role.Company).OrderByDescending(x => x.CreatedBy).ToList();
        }
    }
}
