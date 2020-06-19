using Microsoft.EntityFrameworkCore;

namespace NorusProject.Models {
    public class NorusProjectContext : DbContext {
        public NorusProjectContext(DbContextOptions<NorusProjectContext> options) : base(options) {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
    }
}
