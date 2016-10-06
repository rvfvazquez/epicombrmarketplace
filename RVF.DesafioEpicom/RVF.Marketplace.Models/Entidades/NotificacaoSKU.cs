using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVF.Marketplace.Models
{
    public class NotificacaoSKU
    {
        public string tipo { get; set; } 
        public DateTime dataEnvio { get; set; } 
        public Parametros parametros { get; set; }

        //"tipo": "criacao_sku",
        //"dataEnvio": "2015-07-14T13:56:36",
        /*"parametros": {
          "idProduto": 100,
          "idSku": 200
        }*/
    }
}
