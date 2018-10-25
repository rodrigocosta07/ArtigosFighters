using AppEnvioArtigos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.DAL
{
    public class ArtigosContext : DbContext
    {

        public ArtigosContext() : base("ArtigosContext")
        {
        }

        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Revisor> Revisores { get; set; }
        public DbSet<Artigos> Artigos { get; set; }
        public DbSet<AvaliarArtigo> AvaliarArtigos { get; set; }
        public DbSet<Participante_Artigos> Participante_Artigos { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<ArtigosContext>(null);

        }
    }
}