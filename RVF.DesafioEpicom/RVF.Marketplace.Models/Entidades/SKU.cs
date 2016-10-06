using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace RVF.Marketplace.Models
{
    [DataContract]
    public class SKU
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idSKU { get; set; }
        [DataMember]
        public string cdSKU { get; set; }
        [DataMember]
        public int idProduto { get; set; }

        [DataMember]
        public decimal preco { get; set; }


        [DataMember]
        public DateTime? DataCriacao { get; set; }

        [DataMember]
        public DateTime? DataAlteracao { get; set; }


    }
}
