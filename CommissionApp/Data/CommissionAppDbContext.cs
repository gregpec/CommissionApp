using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommissionApp.Entities;

namespace CommissionApp.Data;

//namespace MotoApp.Data;


public class CommissionAppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    // public DbSet<Customer> Customers => Set<Customer>();  //Seller - sprzedawca

    //Customer -zasób
    // = ustawiony metodą Set, która znajduję się w tym kontekscie DbContext
    public DbSet<Car> Cars => Set<Car>();  //Motobike

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)




    //public MotoAppDbContext(DbContextOptions<MotoAppDbContext> options)
    //       : base(options)
    //{
    //}






    // public DbSet<IEntity> YourEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }










    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    // dodanie overrida na metode onconfiguring
    {
        base.OnConfiguring(optionsBuilder); // automatycznie zapisuje

        // ojreslenie jak będzie się nazywała nasza baza w pamieci
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");

        if (!optionsBuilder.IsConfigured)
        {
            Console.WriteLine("Configure Data Base!");
        }
    }


}
