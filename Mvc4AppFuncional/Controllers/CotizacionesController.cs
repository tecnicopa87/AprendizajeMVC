using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4AppFuncional.Models;
using System.Web.UI.WebControls;

namespace Mvc4AppFuncional.Controllers
{
    public class CotizacionesController : Controller
    {
        private AlmacenEntities db = new AlmacenEntities();

        //
        // GET: /Cotizaciones/
        public ActionResult Index(BodegaCotizacionSheme modelo,string[] prodids)
        {
            string usuario = System.Web.HttpContext.Current.Session["UsuarioWindows"] as string ;
            if (usuario == null)
            {
               // return RedirectToAction("Login", "Account");
                //return View("~/Views/Account/Login.cshtml");
            }
            // ---
        long[] getid=null;
        if (prodids != null)
        {
            getid = new long[prodids.Length];
            int j = 0;
            foreach (string i in prodids)
            {
                long.TryParse(i, out getid[j++]);
            }
            List<Bodegas> getprodids = new List<Bodegas>();
            getprodids = db.Bodegas.Where(x => getid.Contains(x.Identificador)).ToList();

        }
    
            // --
            if (modelo.IdCategoria == 0)
            {
                ViewBag.NombreUsuario = usuario;
                var Cotizaciones = db.Cotizaciones.Include(c => c.Clientes);
                BodegaCotizacionSheme bcModel = new BodegaCotizacionSheme();
                bcModel.Id = "1";
                List<Bodegas> lstB = new List<Bodegas>();
                //Bodegas bo = new Bodegas();
                List<Cotizaciones> lstC = new List<Cotizaciones>();
                //Cotizaciones co = new Cotizaciones();
                List<Categorias> lstCa = new List<Categorias>();
                //Categorias ca = new Categorias();

                lstB = db.Bodegas.ToList();
                lstC=db.Cotizaciones.ToList();
                lstCa = db.Categorias.ToList();
                //bc.lstbcCotizacion = db.Cotizaciones.ToList();
                //bc.lstbcBodega = db.Bodegas.ToList();
                //bc.lstbcCategoria = db.Categorias.ToList();
                                     
                ViewBag.listaProductos = db.Bodegas.ToList();
                bcModel.vBodegas = lstB;
                bcModel.vCategorias = lstCa;
                bcModel.vCotizacion = lstC;
                
                return View(bcModel);//Cotizaciones.ToList());
            }
            else
            {
                var Cotizaciones = db.Cotizaciones.Include(c => c.Clientes);
                //modelo.lstbcCotizacion = db.Cotizaciones.ToList();
                //int SelectID = 0;
                //foreach (var itm in modelo.lstbcCategoria)
                //{
                //    SelectID = itm.IdCategoria;//aqui ya no es la forma?
                //}
                //int sel = SelectID;
                modelo.vCategorias = db.Categorias.ToList();
                modelo.vBodegas = db.Bodegas.Where(a => a.IdCategoria == modelo.IdCategoria).ToList();
                //modelo.lstbcCategoria = db.Categorias.ToList();
                //modelo.lstbcBodega = db.Bodegas.Where(a => a.IdCategoria == SelectID).ToList();
                ViewBag.listaProductos = modelo.vBodegas;//db.Bodegas.ToList();
                return View(modelo);
            }
        }
              
        public ActionResult MetodoImpresion(int? id)
        {
            string output = "salida json";
           return Json(output, JsonRequestBehavior.AllowGet);
        }
    [HttpGet]
        public ActionResult AgregarProductos(FormCollection objetos)
        {
            var objt = Convert.ToString(Request.Form["chkCalifica"]);
            objt = Convert.ToString(Session["chks"]);
        //En la vista recupero objetosForm por jajascript
        List<Bodegas> modelA = new List<Bodegas>();
            modelA = db.Bodegas.ToList();
            return View(modelA );
        }
        //
        // GET: /Cotizaciones/Details/5
        public ActionResult Details(int id = 0)
        {
            Cotizaciones Cotizaciones = db.Cotizaciones.Find(id);
            if (Cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(Cotizaciones);
        }

        //
        // GET: /Cotizaciones/Create

        public ActionResult Create()
        {
            ViewBag.NoCliente = new SelectList(db.Clientes, "NoCliente", "NombreCliente");
            return View();
        }

        //
        // POST: /Cotizaciones/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cotizaciones Cotizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Cotizaciones.Add(Cotizaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NoCliente = new SelectList(db.Clientes, "NoCliente", "NombreCliente", Cotizaciones.NoCliente);
            return View(Cotizaciones);
        }

        //
        // GET: /Cotizaciones/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cotizaciones Cotizaciones = db.Cotizaciones.Find(id);
            if (Cotizaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoCliente = new SelectList(db.Clientes, "NoCliente", "NombreCliente", Cotizaciones.NoCliente);
            return View(Cotizaciones);
        }

        //
        // POST: /Cotizaciones/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cotizaciones Cotizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Cotizaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NoCliente = new SelectList(db.Clientes, "NoCliente", "NombreCliente", Cotizaciones.NoCliente);
            return View(Cotizaciones);
        }

        //
        // GET: /Cotizaciones/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cotizaciones Cotizaciones = db.Cotizaciones.Find(id);
            if (Cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(Cotizaciones);
        }

        //
        // POST: /Cotizaciones/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotizaciones Cotizaciones = db.Cotizaciones.Find(id);
            db.Cotizaciones.Remove(Cotizaciones);
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