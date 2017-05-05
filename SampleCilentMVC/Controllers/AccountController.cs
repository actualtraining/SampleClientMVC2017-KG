using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BO;
using ServicesBackend;
using System.Threading.Tasks;

namespace SampleCilentMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username,string password)
        {
            AccountServices accountServices = new AccountServices();
            try
            {
                var result = await accountServices.Login("erick@gmail.com", "Erick@123");

                var strToken = result.access_token;
                Session["token"] = strToken;
                return RedirectToAction("Index", "Kategori");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "<span class='alert alert-danger'>" + ex.Message + "</span>";
                return View();
            }
        }
    }
}