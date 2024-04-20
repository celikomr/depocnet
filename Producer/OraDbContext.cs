using Microsoft.EntityFrameworkCore;

namespace Producer;

public class OraDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
