using EticaretV1.Model.Option;
using EticaretV1.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Service.Option
{
   public class CategoryService:ServiceBase<Category>
    {
        public List<Category> ListCategories()
        {
            return GetDefault(x => x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated).OrderByDescending(x=>x.CreatedDate).ToList();
        }
    }
}
