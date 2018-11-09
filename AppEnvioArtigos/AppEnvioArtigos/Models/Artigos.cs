using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;


namespace AppEnvioArtigos.Models
{
    public class Artigos
    {

        public enum Generos
        {
            Tecnologia = 0,
            Ciencia = 1, 
            Medicina = 2,
            Historia = 3
        }


        [Key]
        public int ArtigoID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Digite um resumo do artigo")]
        public string ResumoArtigo { get; set; }

        public Generos Genero { get; set; }

        public byte[] Artigopdf { get; set; }
        public string ContentType { get; set; }


        public virtual ICollection<AvaliarArtigo> Avaliacoes { get; set; }
        public virtual ICollection<Participante> Participantes { get; set; }

    }

    
}