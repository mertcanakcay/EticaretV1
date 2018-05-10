using EticaretV1.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretV1.UI.Areas.Member.Models
{
    public class ProductUpdateDTO
    {
        public List<Category> CategoryList { get; set; }
        public ImagesForProducts ImageForProducts { get; set; }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public Guid ProductID { get; set; }
        public string ImagePath1 { get; set; }


    }
}