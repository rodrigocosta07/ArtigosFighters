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
    public class AvaliarArtigoController : Controller
    {
        private ArtigosContext db = new ArtigosContext();

        // GET: AvaliarArtigo
        public ActionResult Index()
        {
            return View(db.AvaliarArtigos.ToList());
        }

        // GET: AvaliarArtigo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvaliarArtigo avaliarArtigo = db.AvaliarArtigos.Find(id);
            if (avaliarArtigo == null)
            {
                return HttpNotFound();
            }
            return View(avaliarArtigo);
        }

        // GET: AvaliarArtigo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliarArtigo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvaliacaoID,NotaArtigo,ComentarioRevisao")] AvaliarArtigo avaliarArtigo)
        {
            if (ModelState.IsValid)
            {
                db.AvaliarArtigos.Add(avaliarArtigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avaliarArtigo);
        }

        // GET: AvaliarArtigo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvaliarArtigo avaliarArtigo = db.AvaliarArtigos.Find(id);
            if (avaliarArtigo == null)
            {
                return HttpNotFound();
            }
            return View(avaliarArtigo);
        }

        // POST: AvaliarArtigo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvaliacaoID,NotaArtigo,ComentarioRevisao")] AvaliarArtigo avaliarArtigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliarArtigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avaliarArtigo);
        }

        // GET: AvaliarArtigo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvaliarArtigo avaliarArtigo = db.AvaliarArtigos.Find(id);
            if (avaliarArtigo == null)
            {
                return HttpNotFound();
            }
            return View(avaliarArtigo);
        }

        // POST: AvaliarArtigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvaliarArtigo avaliarArtigo = db.AvaliarArtigos.Find(id);
            db.AvaliarArtigos.Remove(avaliarArtigo);
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
