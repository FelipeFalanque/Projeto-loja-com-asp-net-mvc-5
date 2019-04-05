using LojaCFF.UI.Models;
using System.Data.Entity;

namespace LojaCFF.UI.Data
{
    public class LojaCFFDataContext : DbContext
    {
        public LojaCFFDataContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LojaCFF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}