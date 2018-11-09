﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using static AppEnvioArtigos.Models.Artigos;

namespace AppEnvioArtigos.Controllers
{
    public class ArtigoViewModel
    {
        public virtual string Nome { get; set; }
        [Display(Name = "Digite um resumo do artigo")]
        public virtual string ResumoArtigo { get; set; }
        public virtual Generos Genero { get; set; }
        public virtual HttpPostedFileBase Arquivo { get; set; }
        
    }

    public class ArtigoController : Controller
    {
        private ArtigosContext db = new ArtigosContext();

        // GET: Artigo
        public ActionResult Index()
        {
            /*
            ViewBag.Genero = (from c in db.Artigos
                               select c.Genero).Distinct();

            var model = from c in db.Artigos
                        orderby c.Genero
                        where c.Genero == Generos || pais.Equals(null) || pais.Equals("")
                        select c;
            var listAtigo = db.Artigos.Where(x => x.Genero == Generos.Ciencia).ToList();
            */
            return View();
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
                ResumoArtigo = model.ResumoArtigo,
                Genero = model.Genero
                
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
                var id = Session["usuarioLogadoID"].ToString();
                List<Participante> listParticipante = new List<Participante>();
                Participante participante = db.Participantes.Find(int.Parse(id));
                listParticipante.Add(participante);
                artigo.Participantes = listParticipante;
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
