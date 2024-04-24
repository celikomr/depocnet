using Microsoft.EntityFrameworkCore;

namespace Producer;

public class OraDbContext(DbContextOptions<OraDbContext> options) : DbContext(options)
{
    public DbSet<QuoteOra> Quotes { get; set; }
}
