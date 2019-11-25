using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
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

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
              CancellationToken cancellationToken = default(CancellationToken))
        {
            Triggers<BatchModel>.Inserting +=
                     async entry => {                         
                         StockModel stock = await StockModel.FirstOrDefaultAsync(s => s.Fruit == entry.Entity.Fruit && s.Variety == entry.Entity.Variety);
                         if (stock != null)
                         {
                             stock.Quantity += entry.Entity.Quantity;                             
                         }
                     };
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync,
                     acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
        }
    } 
}
