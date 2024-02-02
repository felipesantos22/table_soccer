using fc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace fc.Infra.Data;

public class DataContext: DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }
    public DbSet<Team> Teams { get; set; }
}