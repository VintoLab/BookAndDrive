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
                    CarStatusId = 1,
                    Photo = [
                        255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 2, 0, 0, 72,
                        0, 72, 0, 0, 255, 219, 0, 67, 0, 8, 6, 6, 7, 6, 5, 8, 7, 7, 7,
                        9, 9, 8, 10, 12, 20, 13, 12, 11, 11, 12, 25, 18, 19, 15, 20, 30,
                        26, 31, 30, 30, 26, 29, 29, 32, 36, 46, 39, 32, 34, 44, 35, 29,
                        29, 40, 55, 41, 44, 48, 49, 52, 52, 52, 31, 39, 57, 61, 56, 50,
                        60, 46, 51, 52, 50, 255, 192, 0, 17, 8, 0, 100, 0, 100, 3, 1, 34,
                        0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 31, 0, 0, 1, 5, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8,
                        9, 10, 11, 255, 218, 0, 12, 3, 1, 0, 2, 17, 3, 17, 0, 63, 0, 215,
                        244, 50, 15, 255, 217
                    ]
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
                    CarStatusId = 2,
                    Photo = [
                        255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 2, 0, 0, 72,
                        0, 72, 0, 0, 255, 219, 0, 67, 0, 8, 6, 6, 7, 6, 5, 8, 7, 7, 7,
                        9, 9, 8, 10, 12, 20, 13, 12, 11, 11, 12, 25, 18, 19, 15, 20, 30,
                        26, 31, 30, 30, 26, 29, 29, 32, 36, 46, 39, 32, 34, 44, 35, 29,
                        29, 40, 55, 41, 44, 48, 49, 52, 52, 52, 31, 39, 57, 61, 56, 50,
                        60, 46, 51, 52, 50, 255, 192, 0, 17, 8, 0, 100, 0, 100, 3, 1, 34,
                        0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 31, 0, 0, 1, 5, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8,
                        9, 10, 11, 255, 218, 0, 12, 3, 1, 0, 2, 17, 3, 17, 0, 63, 0, 215,
                        244, 50, 15, 255, 217
                    ]
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
                    CarStatusId = 3,
                    Photo = [
                        255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 2, 0, 0, 72,
                        0, 72, 0, 0, 255, 219, 0, 67, 0, 8, 6, 6, 7, 6, 5, 8, 7, 7, 7,
                        9, 9, 8, 10, 12, 20, 13, 12, 11, 11, 12, 25, 18, 19, 15, 20, 30,
                        26, 31, 30, 30, 26, 29, 29, 32, 36, 46, 39, 32, 34, 44, 35, 29,
                        29, 40, 55, 41, 44, 48, 49, 52, 52, 52, 31, 39, 57, 61, 56, 50,
                        60, 46, 51, 52, 50, 255, 192, 0, 17, 8, 0, 100, 0, 100, 3, 1, 34,
                        0, 2, 17, 1, 3, 17, 1, 255, 196, 0, 31, 0, 0, 1, 5, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8,
                        9, 10, 11, 255, 218, 0, 12, 3, 1, 0, 2, 17, 3, 17, 0, 63, 0, 215,
                        244, 50, 15, 255, 217
                    ]
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
