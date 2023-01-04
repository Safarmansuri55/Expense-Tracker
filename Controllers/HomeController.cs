using Expanse_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expanse_Manager.Controllers
{
    public class HomeController : Controller
    {
        //database context object for fething the data
        expensedbEntities1 context = new expensedbEntities1();
        public ActionResult Index()
    {
        return View();
    }
    public ActionResult catagory()
    {

        return View();
    }
    public ActionResult catagory2()
    {

        return View();
    }
    public ActionResult expense()
    {
        return View();
    }
    public ActionResult expense2()
    {
        return View();

    }
    public ActionResult limit()
    {
        return View();
    }
    public ActionResult signup() {
        return View();
    }

    //for adding a new user
    public ActionResult Addsignup(user model)
    {

            var userobj = new user();
            userobj.username = model.username;
            userobj.email = model.email;
            userobj.password = model.password;
            userobj.confirm_password = model.confirm_password;

            //adding the collected data
            context.users.Add(userobj);
            context.SaveChanges();

        return View();
    }

    public ActionResult login() {

        return View();
    }




    }
}