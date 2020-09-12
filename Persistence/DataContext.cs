using System;
using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Value> Value {get;set;}

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Value>().HasData(
            new Value{Id=1, Name="Raghu"},
            new Value{Id=2, Name="Raghu1"},
            new Value{Id=3, Name="Raghu2"},
            new Value{Id=4, Name="Raghu3"}
        );
    }
    }
}
