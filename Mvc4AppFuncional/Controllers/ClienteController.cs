using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4AppFuncional.Models;

namespace Mvc4AppFuncional.Controllers
{
    public class ClienteController : Controller
    {
        private AlmacenEntities db = new AlmacenEntities();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            ViewData["UsuarioWindows"] = System.Web.HttpContext.Current.Session["UsuarioWindows"] as string ;
            string Usuario = System.Web.HttpContext.Current.Session["UsuarioWindows"] as string;
            
            if (Usuario == null)
            {
                return View ("~/Views/Home/Index.cshtml");
            }
            //foreach (var itm in ViewData["UsuarioWindows"] as string )
            //{
            //    if (itm[0].ToString() != "")
            //    {
                   // Response.Redirect("/Home/Index.cshtml");
            //    };
            //}
           
            ViewBag.login = Usuario ;
            if (TempData["PasswordMvc"]!= null)
            {
                string paswd = TempData["PasswordMvc"].ToString();
            }            
            return View(db.Clientes.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            Clientes cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Clientes cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Volummercancia = new List<SelectListItem> {
             new SelectListItem {Text="menor 500kg",Value ="A"},
             new SelectListItem {Text="entre 500 y 800kg",Value ="B"},
             new SelectListItem {Text="mayor a 1000kg",Value ="C"}
            };
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                if (cliente.PrioridadVenta != null)
                {
                    HttpCookie ck=new HttpCookie("info_adicional","respondida");
                    Response.Cookies.Add(ck);
                }
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Clientes cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}