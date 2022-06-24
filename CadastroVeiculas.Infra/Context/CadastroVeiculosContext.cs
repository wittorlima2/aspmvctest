using CadastroVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace CadastroVeiculos.Infra.Data.Context
{
    public class CadastroVeiculosContext : DbContext
    {
        public static readonly LoggerFactory _myLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public CadastroVeiculosContext(DbContextOptions<CadastroVeiculosContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Veiculo>()
                .HasOne(t => t.Proprietario)
                .WithMany(t => t.Veiculos)
                .HasForeignKey(f => f.ProprietarioId);

            modelBuilder.Entity<Veiculo>()
                .HasOne(t => t.Marca)
                .WithMany(t => t.Veiculos)
                .HasForeignKey(f => f.MarcaId);

        }
    }
}
