using Expanse_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Expanse_Manager.Controllers
{
    public class HomeController : Controller
    {
        //database context object for fething the data
        expensedbEntities2 context = new expensedbEntities2();
        public ActionResult Index()
    {
        return View();
    }

        public ActionResult signup()
        {
            return View();
        }
        //for adding a new user
        [HttpPost]
        public ActionResult Addsignup(user model)
    {

            var userobj = new user();
            userobj.user_id = model.user_id;
            userobj.username = model.username;
            userobj.email = model.email;
            userobj.password = model.password;
           

            //adding the collected data
            context.users.Add(userobj);
            context.SaveChanges();

        return RedirectToAction ("Index","Home");
    }

        public ActionResult catagory()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Addcatagory(catagory model) {

            catagory catobj = new catagory();
            catobj.catagory_id = model.catagory_id;
            catobj.catagory_name = model.catagory_name;
            catobj.catagory_limit = model.catagory_limit;
            context.catagories.Add(catobj);

            context.SaveChanges();



            return RedirectToAction("Index", "Home");
        }


        public ActionResult ListofCartagories(catagory model) {

            var fetch = context.catagories.ToList();

            return View(fetch);
        
        }
        public ActionResult expense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addexpense(expense model)
        {

            expense expobj = new expense();
            expobj.expense_id = model.expense_id;
            expobj.Title = model.Title;
            expobj.Discription = model.Discription;
            expobj.datetime = model.datetime;
            expobj.amount = model.amount;
            expobj.catagory = model.catagory;


            context.expenses.Add(expobj);
            context.SaveChanges();



            return RedirectToAction("ListExpense","Home");
        }

    
        public ActionResult ListExpense(expense model)
        {

            var fetch = context.expenses.ToList();


            return View(fetch);

        }

        //edit and delete expense
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var obj = context.expenses.SingleOrDefault(m => m.expense_id == id);


            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(expense ex)
        {
            context.Entry(ex).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = context.expenses.SingleOrDefault(m => m.expense_id == id);


            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(expense ex)
        {
            context.Entry(ex).State = System.Data.Entity.EntityState.Deleted;
            
            try
            {
                context.SaveChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            
            }
            return RedirectToAction("Index","Home");
        }

        //catagory edit delete
        [HttpGet]
        public ActionResult Editc(int id)
        {
            var obj1 = context.catagories.SingleOrDefault(m => m.catagory_id == id);


            return View(obj1);
        }
        [HttpPost]
        public ActionResult Editc(catagory ex)
        {
            context.Entry(ex).State = System.Data.Entity.EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            { 
               Console.Write(e.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Deletec(int id)
        {
            var obj = context.catagories.SingleOrDefault(m => m.catagory_id == id);


            return View(obj);
        }
        [HttpPost]
        public ActionResult Deletec(catagory ex1)
        {
            context.Entry(ex1).State = System.Data.Entity.EntityState.Deleted;
            
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return RedirectToAction("Index", "Home");
        }






        public ActionResult ListExpense2(expense model)
        {

            var fetch = context.expenses.ToList();


            return View(fetch);

        }




        public ActionResult limit() {
            return View();
        }
        [HttpPost]
        public ActionResult Addlimit(total_limit model)
        {

            total_limit tobj = new total_limit();
            tobj.total_id = model.total_id;
            tobj.total_limit1 = model.total_limit1;

            context.total_limit.Add(tobj);

            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Listlimit(total_limit model)
        { 
            var fetch = context.total_limit.ToList();
            
            return View(fetch);
        }



        public ActionResult login() {





        return View();
    }

        //login code
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var u_password = GetMD5(password);
                var data = context.users.Where(x => x.email == email && x.password == password).ToList();
                if (data.Count() > 0)
                {
                    Session["username"] = data.FirstOrDefault().username;
                    Session["email"] = data.FirstOrDefault().email;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "UserName or password is wrong";
                    return RedirectToAction("login");
                }
            }
            return View();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult getlimit(int id)
        {

            var data = context.total_limit.Where(x => x.total_id == id).FirstOrDefault();
            ViewBag.data1 = data;
            return View(data); 


        }

        public ActionResult signout() {


            return RedirectToAction("login","Home");
        
        }





    }
}