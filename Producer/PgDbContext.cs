using Microsoft.EntityFrameworkCore;

namespace Producer;

public class PgDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
