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

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Digite um resumo do artigo")]
        public string ResumoArtigo { get; set; }
        
        public byte[] Artigopdf { get; set; }
        public string ContentType { get; set; }

        public virtual Participante Participante { get; set; }
        public virtual ICollection<AvaliarArtigo> AvaliarArtigos { get; set; }
        
    }

    
}