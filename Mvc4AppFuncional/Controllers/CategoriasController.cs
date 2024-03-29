﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4AppFuncional.Models;

namespace Mvc4AppFuncional.Controllers
{
    public class CategoriasController : Controller
    {
        private AlmacenEntities db = new AlmacenEntities();

        //
        // GET: /Categorias/

        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        //
        // GET: /Categorias/Details/5

        public ActionResult Details(int id = 0)
        {
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        //
        // GET: /Categorias/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categorias/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorias);
        }

        //
        // GET: /Categorias/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        //
        // POST: /Categorias/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorias categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias);
        }

        //
        // GET: /Categorias/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Categorias categorias = db.Categorias.Find(id);
            if (categorias == null)
            {
                return HttpNotFound();
            }
            return View(categorias);
        }

        //
        // POST: /Categorias/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorias categorias = db.Categorias.Find(id);
            db.Categorias.Remove(categorias);
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