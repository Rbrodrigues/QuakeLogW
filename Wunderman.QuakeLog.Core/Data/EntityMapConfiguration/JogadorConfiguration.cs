using System.Data.Entity.ModelConfiguration;
using Wunderman.QuakeLog.Core.Domain.Entities;

namespace Wunderman.QuakeLog.Core.Data.EntityMapConfiguration
{
    public class JogadorConfiguration : EntityTypeConfiguration<Jogador>
    {
        public JogadorConfiguration()
        {
            Property(x => x.Nome)
              .HasColumnName("Nome")
              .HasMaxLength(100);

            Property(x => x.QuantidadeEliminacoes)
                .HasColumnName("QuantidadeEliminacoes");

            Property(x => x.QuantidadeMortes)
                .HasColumnName("QuantidadeMortes");           
        }
    }
}
