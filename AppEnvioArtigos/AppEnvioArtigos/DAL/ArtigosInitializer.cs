using AppEnvioArtigos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.DAL
{
    public class ArtigosInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ArtigosContext>
    {
        protected override void Seed(ArtigosContext context)
        {
            var Participantes = new List<Participante>
            {
            new Participante{Nome="Carson", NumInscricao= 1231,Email="aa@aaa.com", Senha="321", RepitaSenha="321", LocalParticipacao="lauro", Telefone="2345"}
            };

            Participantes.ForEach(s => context.Participantes.Add(s));
            context.SaveChanges();
        }
    }
}