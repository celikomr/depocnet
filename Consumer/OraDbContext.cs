using Microsoft.EntityFrameworkCore;

namespace Consumer;

public class OraDbContext : DbContext
{
    public DbSet<QuoteOra> Quotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle("Data Source=C:\\Users\\OmerCelik\\source\\repos\\EFCoreSamples\\EFCoreSamples\\mydatabase.db");
    }
}
