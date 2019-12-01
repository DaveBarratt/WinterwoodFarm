using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winterwood_Farm.Models;

namespace Winterwood_Farm.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.StockModel.Any())
            {
                return;   // DB has been seeded
            }

            var stocks = new StockModel[]
            {
                new StockModel{Fruit="Raspberry",Variety="Amira",Quantity=12},
                new StockModel{Fruit="Raspberry",Variety="Erika",Quantity=10},
                new StockModel{Fruit="Bueberry",Variety="Alba",Quantity=15},
            };
            foreach (StockModel s in stocks)
            {
                context.StockModel.Add(s);
            }
            context.SaveChanges();

            var batches = new BatchModel[]
            {
                new BatchModel{Fruit="Raspberry",Variety="Amira",Quantity=12},
                new BatchModel{Fruit="Raspberry",Variety="Erika",Quantity=10},
                new BatchModel{Fruit="Raspberry",Variety="Amira",Quantity=10},
                new BatchModel{Fruit="Bueberry",Variety="Alba",Quantity=15},
            };
            foreach (BatchModel b in batches)
            {
                context.BatchModel.Add(b);
            }
            context.SaveChanges();
        }
    }
}
