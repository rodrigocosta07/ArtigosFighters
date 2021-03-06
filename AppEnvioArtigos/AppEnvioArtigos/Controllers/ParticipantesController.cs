﻿using System;
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
    public class ParticipantesController : Controller
    {
        private ArtigosContext db = new ArtigosContext();

        // GET: Participantes
        public ActionResult Index()
        {

            return View(db.Participantes.ToList());
        }


        // GET: Participantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParticipanteID,NumInscricao,Perfil,Nome,Telefone,Email,LocalParticipacao,Senha,RepitaSenha,Endereco,CartaoCredito")] Participante participante)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {   // verifica se o email informado já esta no banco.
                    var consultaBanco = db.Participantes.Where(model => model.Email.Equals(participante.Email)).FirstOrDefault();
                    if (consultaBanco != null)
                    {
                        ViewBag.Email = "Email Já cadastrado";
                        return View(participante);
                    }

                        db.Participantes.Add(participante);
                        db.SaveChanges();
                        return RedirectToAction("Login", "Participantes");

                }

            }

            return View(participante);
        }
    
        // Tela de login , serve para redenrizar (ação get) .
        public ActionResult Login()
        {   // quando clica em sair, a session recebe null.    
            Session["usuarioLogadoID"] = null;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Senha")]Participante participante)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                using (db)
                {
                    var v = db.Participantes.Where(a => a.Email.Equals(participante.Email) && participante.Senha.Equals(participante.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["usuarioLogadoID"] = v.ParticipanteID.ToString();
                        Session["EmailUsuarioLogado"] = v.Email.ToString();
                        Session["NomeUsuarioLogado"] = v.Nome.ToString();
                        Session["Perfil"] = v.Perfil.ToString();
                        return RedirectToAction("Index", "Artigo");
                    }
                    else
                    {
                        ViewBag.ErroLogin = "Email ou senha invalidos";
                        return View(participante);
                    }
                }


            }
            return View(participante);
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
