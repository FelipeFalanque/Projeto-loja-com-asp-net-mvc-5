using LojaCFF.UI.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace LojaCFF.UI.Data
{
    public class DbInitializer : CreateDatabaseIfNotExists<LojaCFFDataContext>
    {
        protected override void Seed(LojaCFFDataContext context)
        {
            var produtos = new List<Produto>() {
                new Produto() { Nome = "Picanha", Preco = 70.5M, Qtde= 150, Tipo = "Alimento"},
                new Produto() { Nome = "Pasta de dente", Preco = 9.5M, Qtde= 250, Tipo = "Higiene"},
                new Produto() { Nome = "Desinfetante", Preco = 8.99M, Qtde= 520, Tipo = "Limpeza"},
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }
    }
}