using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//este controlador va averificar si esta el usuario 
namespace Sys.Inventario.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string email, string password)
        {
            return View();
        }

    }
}