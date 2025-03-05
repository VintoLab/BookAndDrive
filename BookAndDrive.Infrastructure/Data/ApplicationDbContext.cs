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
                },
                new CarStatus
                {
                    Id = 2,
                    Name = "Booked",
                },
                new CarStatus
                {
                    Id = 3,
                    Name = "Service",
                }
            );

            modelBuilder.Entity<CarType>().HasData(
                new CarType
                {
                    Id = 1,
                    Name = "City",
                },
                new CarType
                {
                    Id = 2,
                    Name = "Large City",
                },
                new CarType
                {
                    Id = 3,
                    Name = "Electric",
                },
                new CarType
                {
                    Id = 4,
                    Name = "Small Van",
                },
                new CarType
                {
                    Id = 5,
                    Name = "Large Van",
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
                },
                new Car
                {
                    Id = 2,
                    Seats = 5,
                    Transmission = "Manual",
                    Brand = "Renault",
                    Year = 2024,
                    VIN = "12345678912345679",
                    Price = 10.0M,
                    CarTypeId = 1,
                    CarStatusId = 2
                },
                new Car
                {
                    Id = 3,
                    Seats = 4,
                    Transmission = "Manual",
                    Brand = "Renault",
                    Year = 2024,
                    VIN = "12345678912345671",
                    Price = 10.0M,
                    CarTypeId = 1,
                    CarStatusId = 3
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Vinto",
                    Email = "tomvinto@gmail.com",
                    Password = "479b0b6509920e075f50000e3a1f6deb44a50303c9d8ecfa66f4ff16e66e60a2", //qwerty1!
                    PhoneNumber = "+380231231231",
                },
                new User
                {
                    Id = 2,
                    FirstName = "Alex",
                    LastName = "Vinto",
                    Email = "alexvinto@gmail.com",
                    Password = "479b0b6509920e075f50000e3a1f6deb44a50303c9d8ecfa66f4ff16e66e60a2", //qwerty1!
                    PhoneNumber = "+380631887836",
                    Role = "Admin"
                }
            );
        }

    }
}
