using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class EnviarArtigo
    {
        [Key]
        public int ArtigoId { get; set; }
        public string Nome { get; set; }
        public string ResumoArtigo { get; set; }
        public byte[] ArqArtigo { get; set; }

       
    }

}