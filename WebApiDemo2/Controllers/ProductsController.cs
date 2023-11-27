using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApiDemo2.Models;
using System.Data.SqlClient;

namespace WebApiDemo2.Controllers
{
    public class ProductsController : ApiController
    {
        public List<ProductModel> GetProducts()
        {
            SqlConnection cn = new SqlConnection("server=Sulakshana\\sqlexpress;Integrated Security=true;database=Northwind");
            SqlCommand cmd = new SqlCommand("select * from  products",cn);
            cn.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            List<ProductModel> products = new List<ProductModel>();
            while (dr.HasRows)
            {
                ProductModel productModel = new ProductModel();
                productModel.Prodid = Convert.ToInt32(dr["0"]); 
                productModel.Prodname = dr["1"].ToString();
                productModel.Price = Convert.ToInt32(dr["UnitPrice"]);
                productModel.Qty = Convert.ToInt32(dr["QuantityInHand"]);
                products.Add(productModel); 


            }
            cn.Close();
            return products;    
        }
        //public ProductModel GetProduct(int id) {
        
        //}

        public HttpStatusCode PostProduct(ProductModel product) {
            SqlConnection cn = new SqlConnection("server=Sulakshana\\sqlexpress;Integrated Security=true;database=Northwind");
            SqlCommand cmd = new SqlCommand("insert into product(productname,UnitPrice,QuantityInHand) values (@productname,@UnitPrice,@QuantityInHand)", cn);
            cmd.Parameters.AddWithValue("@productname", product.Prodname);
            cmd.Parameters.AddWithValue("@UnitPrice", product.Price);
            cmd.Parameters.AddWithValue("@QuantityInHand", product.Qty);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            return HttpStatusCode.OK;



        }
        //public void DeleteProduct(int id) { }   
        //public HttpStatusCode PutProduct(ProductModel product) { }



    }
}
