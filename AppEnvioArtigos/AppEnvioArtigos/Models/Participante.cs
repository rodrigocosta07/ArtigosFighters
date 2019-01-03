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

        public enum Usuario
        {
            Participante = 0,
            Revisor = 1

        }
        public int ParticipanteID { get; set; }
        
        public string Nome { get; set; }

       
       
        public Usuario Perfil { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Forneça o número do telefone no formato (000) 00000-0000")]
        public string Telefone { get; set; }

        
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    

        [Display(Name = "Endereço")]
        public  Endereco Endereco { get; set; }
       

        public virtual ICollection<Artigos> Artigos { get; set; }


    }

}