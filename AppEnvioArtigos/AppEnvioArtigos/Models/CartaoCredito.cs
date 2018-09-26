using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppEnvioArtigos.Models
{
    public class CartaoCredito
    {

        public int CartaoCreditoId { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public DateTime Validade { get; set; }
        [Required]
        public string Marca { get; set; }
    }
}