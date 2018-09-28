using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class CartaoCredito
    {
        
        
        public int Numero { get; set; }
        
        public DateTime Validade { get; set; }
        
        public string Marca { get; set; }
    }
}