using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class AvaliarArtigo
    {
        [Key]
        public int AvaliacaoID { get; set; }

        [Required]
        [Display(Name = "Sua nota para o Artigo:")]
        public float NotaArtigo { get; set; }

        [Required]
        [Display(Name = "Envie um comentario sobre o artigo:")]
        public string ComentarioRevisao { get; set; }

        public virtual ICollection<Artigos> Artigos { get; set; }
    }
}