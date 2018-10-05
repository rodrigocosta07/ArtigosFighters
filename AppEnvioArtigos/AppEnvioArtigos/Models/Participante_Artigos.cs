using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class Participante_Artigos
    {
        public int Participante_ArtigosID { get; set; }
        public int ParticipanteID { get; set; }
        public int ArtigoID { get; set; }

        public virtual Participante Participante { get; set; }
        public virtual Artigos Artigos { get; set; }
    }
}