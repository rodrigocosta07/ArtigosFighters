using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AppEnvioArtigos.DAL;
using AppEnvioArtigos.Models;

namespace AppEnvioArtigos.Controllers
{
    public class ArtigoViewModel
    {
        public virtual string Nome { get; set; }
        public virtual string ResumoArtigo { get; set; }
        public virtual HttpPostedFileBase Arquivo { get; set; }
    }

    public class ArtigoController : Controller
    {
        private ArtigosContext db = new ArtigosContext();

        // GET: Artigo
        public ActionResult Index()
        {
            return View(db.Artigos.ToList());
        }

        // GET: Artigo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigos artigos = db.Artigos.Find(id);
            if (artigos == null)
            {
                return HttpNotFound();
            }
            return View(artigos);
        }

        // GET: Artigo/Create
        public ActionResult Create()
        {
            ArtigoViewModel model = new ArtigoViewModel();
            return View(model);
        }

       
        // POST: Artigo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Create(Artigos artigos , HttpPostedFileBase file)
        public ActionResult Create(ArtigoViewModel model)
        {
            var artigo = new Artigos
            {
                Nome = model.Nome,
                ResumoArtigo = model.ResumoArtigo
            };

            if (model.Arquivo != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    model.Arquivo.InputStream.CopyTo(ms);
                    byte[] temp = ms.GetBuffer();
                    if (temp.Length != 0)
                    {
                        artigo.Artigopdf = temp;
                        artigo.ContentType = model.Arquivo.ContentType;
                    }
                }
            }
            if (ModelState.IsValid)
            {
               
                db.Artigos.Add(artigo);
                db.SaveChanges();
                return RedirectToAction("Index" , "Home");
            }

            return View(artigo);
        }

        public ActionResult DownloadDocumento(long id)
        {
            Artigos documento = db.Artigos.Find(id);
            return File(documento.Artigopdf,"application/pdf", documento.Nome);
        }
        /*
        [HttpGet]
        public ActionResult Read(int ID)
        {
            using (db)
            {
                Artigos artigos = db.Artigos.FirstOrDefault(m => m.ArtigoID == ID);
                var base64 = Convert.ToBase64String(artigos.Artigopdf);
                var book = string.Format("data:application/pdf;base64,{0}", base64);
                var article = db.Artigos.Find(ID);
                return File(article.Artigopdf, "application/pdf");
            }
            
        }
        /*
        [HttpGet]
        public FileStreamResult VerArquivo(int id)
        {
            using (db)
            {
                Artigos artigos = db.Artigos.FirstOrDefault(m => m.ArtigoID == id);
                MemoryStream ms = new MemoryStream(artigos.Artigopdf);
                
                return new FileContentResult(artigos.Artigopdf, "application/pdf");
            }
           
        }*/

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
