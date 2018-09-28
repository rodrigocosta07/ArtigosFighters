using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class Participante
    {
        [Key]
        public int ParticipanteId { get; set; }
        
        public string Nome { get; set; }

        
        public int Telefone { get; set; }

        
        public string Email { get; set; }

        
        [Display(Name = "Local De Participação")]
        public string LocalParticipacao { get; set; }
    
        
        public string Senha { get; set; }
        
        [Display(Name = "Repita a sua senha:")]
        public string RepitaSenha { get; set; }

        public  Endereco Endereco { get; set; }
        public  CartaoCredito CartaoCredito { get; set; }
    }

}