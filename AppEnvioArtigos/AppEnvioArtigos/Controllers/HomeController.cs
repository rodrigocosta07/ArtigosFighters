using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppEnvioArtigos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                ViewBag.usuario = Session["NomeUsuarioLogado"];
                return View();
            }
            else
            {
                return RedirectToAction("Login" , "Participantes");
            }
           
        }

    }
}