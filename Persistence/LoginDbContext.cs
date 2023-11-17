using ApiLojaEletronicos.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiLojaEletronicos.Persistence
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Login>(e =>
            {
                e.HasKey(de => de.Id);
                e.Property(de => de.Usuario).IsRequired(true);
                e.Property(de => de.Senha).IsRequired(true);
                e.Property(de => de.Cpf).HasMaxLength(11);
            });
        }
    }
}
