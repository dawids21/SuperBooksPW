using MatuszewskiStasiak.SuperBooks.DAOSQL.BO;
using Microsoft.EntityFrameworkCore;

namespace MatuszewskiStasiak.SuperBooks.Web
{
    public class DataContext: DbContext
    {
            private IConfiguration _configuration;

            public DataContext(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite(_configuration.GetConnectionString("Sqlite"));
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Publisher>()
                    .HasMany(p => (ICollection<Book>)p.Books)
                    .WithOne(b => (Publisher)b.Publisher);
            }

            public virtual DbSet<Publisher> Publishers { get; set; }
            public virtual DbSet<Book> Books { get; set; }
        }
}
