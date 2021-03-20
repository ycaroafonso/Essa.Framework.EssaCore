namespace Mapeia.Models
{
    using Microsoft.EntityFrameworkCore;

    public class FoccusContext : DbContext
    {
        public virtual DbSet<Chave> Chave { get; set; }


        public FoccusContext(DbContextOptions<FoccusContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chave>().HasKey(b => b.table_name);
            modelBuilder.Entity<Chave>().HasKey(b => b.table_schema);
            modelBuilder.Entity<Chave>().HasKey(b => b.column_name);
        }
    }
}