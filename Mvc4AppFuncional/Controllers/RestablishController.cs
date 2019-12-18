using Mvc4AppFuncional.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Mvc4AppFuncional.Controllers
{
    public class RestablishController : Controller
    {
        //
        //private UserProfile dbP = new UserProfile();//<- Lo agrego para acceder base Entity
        private UsersContext dbP = new UsersContext();
        // GET: /Restablish/
        public ActionResult Index(string datos)
        {
            string recibodatos = datos;
            return View();
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult RestablecerLogin(string usuario)
        {
            ViewBag.ReturnUrl = "/Account/Login";
            string contrasenanueva = Membership.GeneratePassword(8, 5);//LocalPasswordModel(model.UserName);
            if (usuario == null)
            {
                return RedirectToAction("Login","Login"); 
            }
            bool ExisteUsuario = WebSecurity.UserExists(usuario);
            if (ExisteUsuario)
            {
                string salt = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(contrasenanueva);
                salt = Convert.ToBase64String(encryted);//WebSecurity.ChangePassword(model.UserName, "nataly", model.Password)<- cuando si conoce pass pero quiere cambiarla
                ViewBag.Passtmp = contrasenanueva;                
                
                return View();
            }
            else
            {
                return Content("El usuario no existe");
            }
            return Redirect("Account/Login");
        }

    }
}
