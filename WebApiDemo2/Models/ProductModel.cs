using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo2.Models
{
    public class ProductModel
    {
        public int Prodid { get; set; }

        public string Prodname { get; set; }
        public int Price { get; set; }
       public int Qty { get; set; }
    }
}