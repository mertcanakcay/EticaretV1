using EticaretV1.Model.Option;
using EticaretV1.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretV1.Service.Option
{
   public class ProductService:ServiceBase<Product>
    {
        public List<Product> ListPendingProducts()
        {
            return GetDefault(x => x.isPending == true && x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<Product> ListAcceptedProduct()
        {
            return GetDefault(x => x.isPending == false && x.Status==Core.Enum.Status.Active || x.Status==Core.Enum.Status.Updated).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public Product FindByProductName(string productName)
        {
            return GetByDefault(x => x.Name == productName);
        }


    }
}
