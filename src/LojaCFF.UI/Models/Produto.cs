using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaCFF.UI.Models
{
    [Table("Produtos")]
    public class Produto : Entity
    {
        [Required, StringLength(150), Column(TypeName = "varchar")]
        public string Nome { get; set; }

        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        [Column("Quantidade")]
        public short Qtde { get; set; }

        public int TipoProdutoId { get; set; }

        [ForeignKey(nameof(TipoProdutoId))]
        public virtual TipoProduto TipoProduto { get; set; }
    }
}