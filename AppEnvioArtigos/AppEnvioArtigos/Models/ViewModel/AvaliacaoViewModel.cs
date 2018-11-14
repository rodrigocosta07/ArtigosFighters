using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models.ViewModel
{
    public class AvaliacaoViewModel
    {
       
        public int ArtigoId { get; set; }
        public float NotaArtigo { get; set; }
        public string ComentarioRevisao { get; set; }
        
    }
}