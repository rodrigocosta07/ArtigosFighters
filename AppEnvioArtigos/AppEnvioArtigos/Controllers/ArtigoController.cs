using System;
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
using AppEnvioArtigos.Models.ViewModel;
using static AppEnvioArtigos.Models.Artigos;
using X.PagedList;


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

        
        public ActionResult Index(string Pesquisa, string Genero, string CurrentFilter, int? page)
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.usuario = Session["NomeUsuarioLogado"];
                List<Artigos> listArtigo = new List<Artigos>();
                listArtigo = db.Artigos.ToList();

                if (Pesquisa != null)
                {
                    page = 1;
                }
                else
                {
                    Pesquisa = CurrentFilter;
                }

                ViewBag.CurrentFilter = Pesquisa;

                switch (Genero)
                {
                    case "Tecnologia":
                        listArtigo = db.Artigos.Where(x => x.Genero == Generos.Tecnologia).ToList();
                        break;
                    case "Ciencia":
                        listArtigo = db.Artigos.Where(x => x.Genero == Generos.Ciencia).ToList();
                        break;
                    case "Medicina":
                        listArtigo = db.Artigos.Where(x => x.Genero == Generos.Medicina).ToList();
                        break;
                    case "Historia":

                        listArtigo = db.Artigos.Where(x => x.Genero == Generos.Historia).ToList();
                        break;
                }

                if (!string.IsNullOrEmpty(Pesquisa))
                listArtigo = listArtigo.Where(c => c.Nome.Contains(Pesquisa)).ToList();
                listArtigo = listArtigo.OrderBy(c => c.Nome).ToList();


                int pageSize = 5;
                int pageNumber = (page ?? 1);

                return View(listArtigo.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "Participantes");
            }


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
            
            var a = artigos.Avaliacoes.ToList();
            if(a.Count == 0 )
            {
                ViewBag.media = "Não há avaliação para esse artigo no momento";
            }
            else
            {
                var media = artigos.Avaliacoes.Average(x => x.NotaArtigo);
                ViewBag.media = "Media das notas:" + media;
            }
            

            return PartialView(artigos);
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
                return RedirectToAction("Index", "Artigo");
            }

            return View(artigo);
        }

        public ActionResult DownloadDocumento(long id)
        {
            Artigos documento = db.Artigos.Find(id);
            return File(documento.Artigopdf, "application/pdf", documento.Nome);
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
