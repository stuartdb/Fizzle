using Fizzle.Controllers;
using Fizzle.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizzle.Data
{
    public class NumberContext : DbContext
    {
        public NumberContext(DbContextOptions<NumberContext> options)
            : base(options)
        {
        }

        public void Initialize()
        {            
            if (Numbers.Any()) return;

            const int maxNumber = 100;

            for (int i = 1; i <= maxNumber ; i++)
            {
                var number = new Number { Initial = i };
                number.Fizzle();
                Numbers.Add(number);
            }                        

            SaveChanges();
        }

        public DbSet<Number> Numbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Number>().ToTable("Number");
        }
    }
}
