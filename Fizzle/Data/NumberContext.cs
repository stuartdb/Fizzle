using Fizzle.Models;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Number> Numbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Number>().ToTable("Number");
        }
    }
}
