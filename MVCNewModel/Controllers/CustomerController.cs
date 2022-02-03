using MVCNewModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNewModel.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        customerDBEntities dbObj = new customerDBEntities();
        public ActionResult Customer(tb_customer obj)
        {

                return View(obj);
                      
        }

        [HttpPost]
        public ActionResult AddCustomer(tb_customer model)
        {

            tb_customer obj = new tb_customer();
          
            if (ModelState.IsValid)
            {
                obj.Customer_Id = model.Customer_Id;
                obj.First_Name = model.First_Name;
                obj.Last_Name = model.Last_Name;
                obj.Country = model.Country;
                obj.Email = model.Email;
                obj.PhoneNo = model.PhoneNo;
                {
                    obj.Created_date = model.Created_date;
                }
               
                if(model.Customer_Id==0)
                {
                    dbObj.tb_customer.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
               
            }

            ModelState.Clear();
            return View("Customer");
        }

        public ActionResult ListCustomer()
        {
            var res = dbObj.tb_customer.ToList();

            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.tb_customer.Where(x =>x.Customer_Id == id).First();
            dbObj.tb_customer.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.tb_customer.ToList();

            return View("ListCustomer",list);
        }
    }
}