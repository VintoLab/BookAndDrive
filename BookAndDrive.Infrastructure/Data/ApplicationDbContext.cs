using BookAndDrive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ExtraType> ExtraTypes { get; set; }
        public DbSet<OrderExtras> OrderExtras { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarStatus> CarStatuses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<OrderCar> OrderCars { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarStatus>().HasData(
                new CarStatus
                {
                    Id = 1,
                    Name = "Available",
                }
                );

            modelBuilder.Entity<CarType>().HasData(
                new CarType
                {
                    Id = 1,
                    Name = "Van",
                }
                );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Seats = 4,
                    Transmission = "Automatic",
                    Brand = "Renault",
                    Year = 2024,
                    VIN = "12345678912345678",
                    Price = 10.0M,
                    CarTypeId = 1,
                    CarStatusId = 1
                }
                );
        }

    }
}
