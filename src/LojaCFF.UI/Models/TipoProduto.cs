using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaCFF.UI.Models
{
    public class TipoProduto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}