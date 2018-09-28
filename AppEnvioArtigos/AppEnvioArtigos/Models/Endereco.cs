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
      
        public string Cep { get; set; }
     
        public int Numero { get; set; }
      
        public string Complemento { get; set; }
    
        public string Bairro { get; set; }
      
        public string Cidade { get; set; }
    
        public string Estado { get; set; }
    }
}