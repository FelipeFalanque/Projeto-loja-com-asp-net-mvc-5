using LojaCFF.UI.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace LojaCFF.UI.Data
{
    public class DbInitializer : CreateDatabaseIfNotExists<LojaCFFDataContext>
    {
        protected override void Seed(LojaCFFDataContext context)
        {
            var alimento = new TipoProduto { Nome = "Alimento" };
            var higiene = new TipoProduto { Nome = "Higiene" };
            var limpeza = new TipoProduto { Nome = "Limpeza" };

            var produtos = new List<Produto>() {
                new Produto() { Nome = "Picanha", Preco = 70.5M, Qtde= 150, TipoProduto = alimento },
                new Produto() { Nome = "Pasta de dente", Preco = 9.5M, Qtde= 250, TipoProduto = higiene },
                new Produto() { Nome = "Desinfetante", Preco = 8.99M, Qtde= 520, TipoProduto = limpeza }
            };

            context.Produtos.AddRange(produtos);

            context.Usuarios.Add(new Usuario { Nome = "Cesar", Email = "cesar@cesar.com", Senha = "123456" });

            context.SaveChanges();
        }
    }
}