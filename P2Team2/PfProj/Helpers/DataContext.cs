namespace PfProj.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using PfProj.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //options.UseInMemoryDatabase("TestDb");
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterClassItem> CharacterClassItems {get; set;}
    public DbSet<Item> Items {get; set;}
}