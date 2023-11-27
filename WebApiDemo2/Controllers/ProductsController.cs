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
            while (dr.Read())
            {
                ProductModel productModel = new ProductModel();
                productModel.Prodid = Convert.ToInt32(dr["ProductID"]); 
                productModel.Prodname = dr["ProductName"].ToString();
                productModel.Price = Convert.ToInt32(dr["UnitPrice"]);
                productModel.Qty = dr["QuantityPerUnit"].ToString();
                products.Add(productModel); 


            }
            cn.Close();
            return products;    
        }
        public ProductModel GetProduct(int id)
        {

            SqlConnection cn = new SqlConnection("server=Sulakshana\\sqlexpress;Integrated Security=true;database=Northwind");
            SqlCommand cmd = new SqlCommand("select * from  products where productid="+ id, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ProductModel productModel = new ProductModel();
            if (dr.HasRows)
            {
                dr.Read();
                
                productModel.Prodid = Convert.ToInt32(dr["ProductID"]);
                productModel.Prodname = dr["ProductName"].ToString();
                productModel.Price = Convert.ToInt32(dr["UnitPrice"]);
                productModel.Qty = dr["QuantityPerUnit"].ToString();
            }


            cn.Close();
            //if (productModel != null)
            //{
            //    return HttpStatusCode.OK;
            //}
            //else
            //{
            //    return HttpStatusCode.NotFound;
            //}
            return productModel;
            
        }

        public HttpStatusCode PostProduct(ProductModel product) {
            SqlConnection cn = new SqlConnection("server=Sulakshana\\sqlexpress;Integrated Security=true;database=Northwind");
            SqlCommand cmd = new SqlCommand("insert into products (productname,UnitPrice,QuantityPerUnit) values (@productname,@UnitPrice,@QuantityPerUnit)", cn);
            cmd.Parameters.AddWithValue("@productname", product.Prodname);
            cmd.Parameters.AddWithValue("@UnitPrice", product.Price);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", product.Qty);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            return HttpStatusCode.OK;



        }
        public void DeleteProduct(int id) {
            SqlConnection cn = new SqlConnection("server=Sulakshana\\sqlexpress;Integrated Security=true;database=Northwind");
            SqlCommand cmd = new SqlCommand("delete  from  products where productid=" + id, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();



        }   
        //public HttpStatusCode PutProduct(ProductModel product) { }



    }
}
