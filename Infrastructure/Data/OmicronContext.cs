using Microsoft.EntityFrameworkCore;
using OmicronCase.Domain.Entities;

namespace OmicronCase.Infrastructure.Data
{
public class OmicronContext : DbContext
{
    public OmicronContext(DbContextOptions<OmicronContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
