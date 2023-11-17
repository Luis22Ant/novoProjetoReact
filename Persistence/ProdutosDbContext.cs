using Microsoft.EntityFrameworkCore;
using ApiLojaEletronicos.Entities;


namespace ApiLojaEletronicos.Persistence
{
    public class ProdutosDbContext : DbContext
    {
        public ProdutosDbContext(DbContextOptions<ProdutosDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>(e =>
            {
                e.HasKey(de => de.Id);
                e.Property(de => de.Nome).IsRequired(true);
            });
        }
    }
}
