using LojaCFF.UI.Models;
using System.Data.Entity;

namespace LojaCFF.UI.Data
{
    public class LojaCFFDataContext : DbContext
    {
        public LojaCFFDataContext() : base("LojaCFFConn")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<TipoProduto> TiposProdutos { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}