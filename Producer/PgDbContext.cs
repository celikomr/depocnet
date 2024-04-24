using Microsoft.EntityFrameworkCore;

namespace Producer;

public class PgDbContext(DbContextOptions<PgDbContext> options) : DbContext(options)
{
    public DbSet<Quote> Quotes { get; set; }
}
