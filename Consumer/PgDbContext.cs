using Microsoft.EntityFrameworkCore;

namespace Consumer;

public class PgDbContext(DbContextOptions<PgDbContext> options) : DbContext(options)
{
    public DbSet<Quote> Quotes { get; set; }
}
