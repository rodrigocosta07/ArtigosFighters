using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class Participante
    {

        public int ParticipanteId { get; set; }
        [Required]
        public string Nome { get; set; }

        [Required]
        public int Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Local De Participação")]
        public string LocalParticipacao { get; set; }
    
        [Required]
        public string Senha { get; set; }
        [Required]
        [Display(Name = "Repita a sua senha:")]
        public string RepitaSenha { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual CartaoCredito CartaoCredito { get; set; }
    }

}