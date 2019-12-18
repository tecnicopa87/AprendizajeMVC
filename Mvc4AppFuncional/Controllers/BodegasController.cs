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
    public class BodegasController : Controller
    {
        private AlmacenEntities db = new AlmacenEntities();

        //
        // GET: /Bodegas/
        public ActionResult Index()
        {
            var bodegas = db.Bodegas.Include(b => b.Categorias);
            return View(bodegas.ToList());
        }

        //
        // GET: /Bodegas/Details/5

        public ActionResult Details(long id = 0)
        {
            Bodegas bodegas = db.Bodegas.Find(id);
            if (bodegas == null)
            {
                return HttpNotFound();
            }
            return View(bodegas);
        }
        public ActionResult ListaProductos(long? id)
        {
            if( id!=null)
            {
                //Probando linq:
                string cvebuscada="023";
                var coleccion = from z in db.Bodegas
                                where z.CveProvedor == cvebuscada
                                orderby z.FechaIngreso descending 
                                select new { z.Descripcion };
                // -
                Bodegas bodega = db.Bodegas.Find(id);
                return View(bodega);
            }
            return View(db.Bodegas.ToList());
        }
        [HttpPost]
        public ActionResult ListaProductos(List<Bodegas> modelA)
        {
            return View(modelA);
        }


        public ActionResult _verGrafico()
        {
            List<Bodegas> modelo = new List<Bodegas>();
            modelo = db.Bodegas.ToList();
            return PartialView(modelo);
        }
        //
        // GET: /Bodegas/Create

        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria");
            return View();
        }

        //
        // POST: /Bodegas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bodegas bodegas)
        {
            if (ModelState.IsValid)
            {
                if (db.Bodegas.Find(bodegas.Identificador) == null)
                {
                    db.Bodegas.Add(bodegas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("El Identificador ya fué asignado");
                }
             
            }

            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria", bodegas.IdCategoria);
            return View(bodegas);
        }

        //
        // GET: /Bodegas/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Bodegas bodegas = db.Bodegas.Find(id);
            if (bodegas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria", bodegas.IdCategoria);
            return View(bodegas);
        }

        //
        // POST: /Bodegas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bodegas bodegas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodegas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria", bodegas.IdCategoria);
            return View(bodegas);
        }

        //
        // GET: /Bodegas/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Bodegas bodegas = db.Bodegas.Find(id);
            if (bodegas == null)
            {
                return HttpNotFound();
            }
            return View(bodegas);
        }

        //
        // POST: /Bodegas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bodegas bodegas = db.Bodegas.Find(id);
            db.Bodegas.Remove(bodegas);
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