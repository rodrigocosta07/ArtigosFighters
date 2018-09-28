using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class Artigos
    {
        [Key]
        public int ArtigoID { get; set; }
        public string Nome { get; set; }
        public string ResumoArtigo { get; set; }
        public byte[] Artigopdf { get; set; }
        public float NotaArtigo { get; set; }
        public string ComentarioRevisao { get; set; }
    }

    
}