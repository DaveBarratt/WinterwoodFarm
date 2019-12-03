using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Winterwood_Farm.Models;

namespace Winterwood_Farm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Winterwood_Farm.Models.StockModel> StockModel { get; set; }
        public DbSet<Winterwood_Farm.Models.BatchModel> BatchModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockModel>().HasAlternateKey(c => new { c.Fruit, c.Variety }).HasName("StockVarietyId");
            base.OnModelCreating(modelBuilder);
        }
    } 
}
