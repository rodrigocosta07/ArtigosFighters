using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class Endereco
    {
        
       
        public string Rua { get; set; }

        
        [RegularExpression(@"^\d{8}$|^\d{5}-\d{3}$", ErrorMessage = "O código postal deverá estar no formato 00000000 ou 00000-000")]
        public string Cep { get; set; }
     
        public int Numero { get; set; }
      
        public string Complemento { get; set; }
    
        public string Bairro { get; set; }
      
        public string Cidade { get; set; }
    
        public string Estado { get; set; }
    }
}