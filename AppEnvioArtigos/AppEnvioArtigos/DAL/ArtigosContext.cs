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
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<CartaoCredito> CartaoCreditos { get; set; }
        public DbSet<Artigos> Artigos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}