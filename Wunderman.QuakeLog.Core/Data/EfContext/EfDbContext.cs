using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Wunderman.QuakeLog.Core.Data.EntityMapConfiguration;
using Wunderman.QuakeLog.Core.Domain.Entities;

namespace Wunderman.QuakeLog.Core.Data.EfContext
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("wundermanDbConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                    .Configure(p => p.HasColumnType("varchar"));
            
            modelBuilder.Entity<Partida>()
                .HasKey(x => x.PartidaId)
                .HasMany(x => x.Jogadores);

            modelBuilder.Entity<Jogador>()
                .HasKey(x => x.JogadorId)
                .HasRequired(x => x.Partida)
                .WithMany(x => x.Jogadores)
                .HasForeignKey(x => x.PartidaId);

            modelBuilder.Configurations.Add(new JogadorConfiguration());
        }
    }
}
