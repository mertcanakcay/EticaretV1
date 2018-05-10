using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Member.Models
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public Guid CategoryId { get; set; }
        public string Quantity { get; set; }
        //public List<Product> CartList { get; set; }
    }
}