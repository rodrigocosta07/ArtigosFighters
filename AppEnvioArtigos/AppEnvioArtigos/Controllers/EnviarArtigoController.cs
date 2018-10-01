using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppEnvioArtigos.DAL;
using AppEnvioArtigos.Models;

namespace AppEnvioArtigos.Controllers
{
    public class EnviarArtigoController : Controller
    {
        private ArtigosContext db = new ArtigosContext();

        // GET: EnviarArtigo
        public ActionResult Index()
        {
            return View(db.EnviarArtigos.ToList());
        }

        // GET: EnviarArtigo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnviarArtigo enviarArtigo = db.EnviarArtigos.Find(id);
            if (enviarArtigo == null)
            {
                return HttpNotFound();
            }
            return View(enviarArtigo);
        }

        // GET: EnviarArtigo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnviarArtigo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtigoId,Nome,ResumoArtigo,ArqArtigo")] EnviarArtigo enviarArtigo)
        {
            if (ModelState.IsValid)
            {
                db.EnviarArtigos.Add(enviarArtigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enviarArtigo);
        }

        // GET: EnviarArtigo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnviarArtigo enviarArtigo = db.EnviarArtigos.Find(id);
            if (enviarArtigo == null)
            {
                return HttpNotFound();
            }
            return View(enviarArtigo);
        }

        // POST: EnviarArtigo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtigoId,Nome,ResumoArtigo,ArqArtigo")] EnviarArtigo enviarArtigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enviarArtigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enviarArtigo);
        }

        // GET: EnviarArtigo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnviarArtigo enviarArtigo = db.EnviarArtigos.Find(id);
            if (enviarArtigo == null)
            {
                return HttpNotFound();
            }
            return View(enviarArtigo);
        }

        // POST: EnviarArtigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnviarArtigo enviarArtigo = db.EnviarArtigos.Find(id);
            db.EnviarArtigos.Remove(enviarArtigo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
