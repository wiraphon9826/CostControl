using CostControlWebsite.Models;
using CostControlWebsite.QueryAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CostControlWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LoginIndex()
        {
            if (Session["User_name"] != null)
            {

                Session["User_name"] = null;
            }


            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(T_Admin t_Admin)
        {
            


            QueryCRUD query = new QueryCRUD();
            
            bool chk = query.CheckLogin(t_Admin.User_name, t_Admin.Password);
            List<T_Admin> listTic = new List<T_Admin>();
            QueryCRUD qr = new QueryCRUD();

            listTic = qr.T_Admins(t_Admin.User_name, t_Admin.Password);
            if (chk == true)
            {
                TempData["User_name"] = t_Admin.User_name;
                Session["User_name"] = t_Admin.User_name;
                Session["Type"] = listTic;



                 return RedirectToAction("Index", "Show");

            }
            else
            {
                TempData["message"] = "User And Password Invalid";
                return View();

            }



        }
    }
}