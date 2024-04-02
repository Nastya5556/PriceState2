using Microsoft.EntityFrameworkCore;
using PriceState.Data.Configurations;
using PriceState.Data.Models;
namespace PriceState.Data;

public class DataContext:DbContext
{
   /* public DataContext(DbContextOptions<DataContext> options):base(options)
    {
   //     Database.Migrate();
    }*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PriceState;Username=postgres;Password=1");
    public DbSet<Organization> Organizations { get; set; }

    public DbSet<PriceOrganization> PriceOrganizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<Region> Regions { get; set; }
    public DbSet<Unit> Units{ get; set; }

    public DbSet<MailToken> MailToken { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {

        new MailTokenConfiguration(mb.Entity<MailToken>()); 
        new UserConfigurations(mb.Entity<User>()); 
        new OrganizationConfigurations(mb.Entity<Organization>()); 
        new PriceOrganizationConfigurations(mb.Entity<PriceOrganization>());
        new ProductConfigurations(mb.Entity<Product>());
        new RegionConfigurations(mb.Entity<Region>());
        new UnitConfigurations(mb.Entity<Unit>());
        base.OnModelCreating(mb);
        
    }
   
}