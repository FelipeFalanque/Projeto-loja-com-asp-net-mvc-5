using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaCFF.UI.Models
{
    [Table("TiposProdutos")]
    public class TipoProduto : Entity
    {
        [Required, StringLength(150), Column(TypeName = "varchar")]
        public string Nome { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}