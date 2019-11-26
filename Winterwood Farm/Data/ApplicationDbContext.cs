using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    } 
}
