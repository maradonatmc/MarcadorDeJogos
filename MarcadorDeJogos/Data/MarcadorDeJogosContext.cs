using Microsoft.EntityFrameworkCore;

namespace MarcadorDeJogos.Models {
    public class MarcadorDeJogosContext : DbContext {
        public MarcadorDeJogosContext(DbContextOptions<MarcadorDeJogosContext> options) : base(options) {
        }

        public DbSet<ConfigGeneral> ConfigGeneral { get; set; }
        public DbSet<Jogadores> Jogadores { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<TipoJogo> TipoJogo { get; set; }

		//public DbSet<MarcacaoGeneral> MarcacaoGeneral { get; set; }
		//public DbSet<EstatisticasPorJogadorGeneral> EstatisticasPorJogadorGeneral { get; set; }
    }
}
