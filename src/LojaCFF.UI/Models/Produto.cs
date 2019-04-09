using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaCFF.UI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Tipo { get; set; }
        public short Qtde { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public int TipoProdutoId { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }
    }
}