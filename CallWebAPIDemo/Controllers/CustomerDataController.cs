using CallWebAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CallWebAPIDemo.Controllers
{
    public class CustomerDataController : Controller
    {
         public ActionResult Index()
        {
            List<Customer> custlist = new List<Customer>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44398/api/Customers");
                //HTTP GET
                var responseTask = client.GetAsync("Customers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Customer[]>();
                    readTask.Wait();

                    var customers = readTask.Result;


                    foreach (var item in customers)
                    {
                        Customer m = new Customer();
                        m.CustomerID = item.CustomerID;
                        m.ContactName = item.ContactName;
                        m.CompanyName = item.CompanyName;
                        m.Address = item.Address;
                        m.City = item.City;
                        m.Country = item.Country;
                        m.PostalCode = item.PostalCode;
                        custlist.Add(m);
                    }
                }
            }

            return View(custlist);
        }

        // GET: CustomerData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerData/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
