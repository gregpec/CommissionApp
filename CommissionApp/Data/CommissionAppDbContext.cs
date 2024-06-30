using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using CommissionApp.Entities;
namespace CommissionApp.Data;
public class CommissionAppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Car> Cars => Set<Car>();  //Motobike
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); 
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");

        if (!optionsBuilder.IsConfigured)
        {
            Console.WriteLine("Configure Data Base!");
        }
    }
}
