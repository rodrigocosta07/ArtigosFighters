using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class Participante
    {
        public int ParticipanteID { get; set; }
        
        public string Nome { get; set; }

       
        [DataType(DataType.PhoneNumber, ErrorMessage = "Forneça o número do telefone no formato (000) 00000-0000")]
        public string Telefone { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int NumInscricao { get; set; }
        
        [Display(Name = "Local De Participação")]
        public string LocalParticipacao { get; set; }
    
        
        public string Senha { get; set; }
        
        [Display(Name = "Repita a sua senha:")]
        public string RepitaSenha { get; set; }

        public  Endereco Endereco { get; set; }
        public  CartaoCredito CartaoCredito { get; set; }

        public virtual ICollection<Participante_Artigos> Participante_Artigos { get; set; }


    }

}