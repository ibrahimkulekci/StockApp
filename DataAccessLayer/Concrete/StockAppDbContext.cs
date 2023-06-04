using Microsoft.EntityFrameworkCore;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Data.Concrete
{
    public class StockAppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-P79UT4Q;Database=StockAppDB;integrated security=true");
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<QuantityUnit> QuantityUnits { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<StockClass> StockClasses { get; set; }
    }
}
