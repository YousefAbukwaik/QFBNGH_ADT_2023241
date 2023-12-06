using Microsoft.EntityFrameworkCore;
using QFBNGH_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

//Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ="|DataDirectory|\Database1.mdf"; Integrated Security = True
//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\QFBNGH_ADT_2023241\QFBNGH_ADT_2023241\QFBNGH_ADT_2023241.Repository\Database1.mdf;Integrated Security=True

namespace QFBNGH_ADT_2023241.Repository
{
    public class VanDBContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Models.Van> Vans { get; set; }
        public virtual DbSet<RentVan> RentVan { get; set; }

        public VanDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {

                builder.UseLazyLoadingProxies();
                builder.UseInMemoryDatabase("Motor");
                //.UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Database1.mdf; Integrated Security = True");

            }
        }

   


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Models.Van>(entity =>
            {
                entity.HasOne(Van => Van.Brand)
                    .WithMany(Brand => Brand.Van)
                    .HasForeignKey(Van => Van.Brand_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RentVan>(entity =>
            {
                entity.HasOne(RentVan => RentVan.Van)
                    .WithMany(Van => Van.RentVan)
                    .HasForeignKey(RentVan => RentVan.Van_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Brand Brand1 = new Brand() { Id = 1, BrandName = "BMW", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };
            Brand Brand4 = new Brand() { Id = 4, BrandName = "Porsche", BrandCountry = "Germany", BrandYear = 1931 };

            Models.Van Van1 = new Models.Van() { Id = 1, VanName = "BMW Van1", VanType = "Swift", VanPrice = 1, NewOrUsed = "new", VanReleaseYear = 2000, VanColor = "black", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = true, Brand_id = 1 };
            Models.Van Van2 = new Models.Van() { Id = 2, VanName = "BMW Van2", VanType = "Ignis", VanPrice = 3, NewOrUsed = "new", VanReleaseYear = 2005, VanColor = "white", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 1 };
            Models.Van Van3 = new Models.Van() { Id = 3, VanName = "BMW Van3", VanType = "Swift", VanPrice = 15, NewOrUsed = "used", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = false, Brand_id = 1 };
            Models.Van Van4 = new Models.Van() { Id = 4, VanName = "BMW Van4", VanType = "Vitara", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 1990, VanColor = "green", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricVan = false, Brand_id = 1 };
            Models.Van Van5 = new Models.Van() { Id = 5, VanName = "Toyota Van1", VanType = "Yaris", VanPrice = 4, NewOrUsed = "new", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 2 };
            Models.Van Van6 = new Models.Van() { Id = 6, VanName = "Toyota Van2", VanType = "Corolla", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 2000, VanColor = "green", VanSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = false, Brand_id = 2 };
            Models.Van Van7 = new Models.Van() { Id = 7, VanName = "Toyota Van3", VanType = "Yaris", VanPrice = 2, NewOrUsed = "new", VanReleaseYear = 2010, VanColor = "white", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = false, Brand_id = 2 };
            Models.Van Van8 = new Models.Van() { Id = 8, VanName = "Toyota Van4", VanType = "Sienna", VanPrice = 10, NewOrUsed = "new", VanReleaseYear = 2017, VanColor = "black", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricVan = true, Brand_id = 2 };
            Models.Van Van9 = new Models.Van() { Id = 9, VanName = "Ferrari Van1", VanType = "Ferrari 488", VanPrice = 10, NewOrUsed = "new", VanReleaseYear = 2011, VanColor = "black", VanSeatNumber = 6, IsLeftWheel = true, FuelType = "gasoline", IsElectricVan = true, Brand_id = 3 };
            Models.Van Van10 = new Models.Van() { Id = 10, VanName = "Ferrari Van2", VanType = "Ferrari 488", VanPrice = 15, NewOrUsed = "used", VanReleaseYear = 2018, VanColor = "red", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = false, Brand_id = 3 };
            Models.Van Van11 = new Models.Van() { Id = 11, VanName = "Ferrari Van3", VanType = "Ferrari 458 Italia", VanPrice = 20, NewOrUsed = "new", VanReleaseYear = 2015, VanColor = "white", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricVan = false, Brand_id = 3 };
            Models.Van Van12 = new Models.Van() { Id = 12, VanName = "Ferrari Van4", VanType = "Ferrari Portofino", VanPrice = 22, NewOrUsed = "new", VanReleaseYear = 2020, VanColor = "black", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 3 };
            Models.Van Van13 = new Models.Van() { Id = 13, VanName = "Porsche Van1", VanType = "Porsche 911", VanPrice = 10, NewOrUsed = "new", VanReleaseYear = 2017, VanColor = "black", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricVan = true, Brand_id = 4 };
            Models.Van Van14 = new Models.Van() { Id = 14, VanName = "Porsche Van2", VanType = "Porsche 968 Turbo S", VanPrice = 100, NewOrUsed = "new", VanReleaseYear = 2016, VanColor = "white", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 4 };
            Models.Van Van15 = new Models.Van() { Id = 15, VanName = "Porsche Van3", VanType = "Porsche 999", VanPrice = 40, NewOrUsed = "used", VanReleaseYear = 2005, VanColor = "black", VanSeatNumber = 6, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = false, Brand_id = 4 };
            Models.Van Van16 = new Models.Van() { Id = 16, VanName = "Porsche Van4", VanType = "Porsche 999", VanPrice = 35, NewOrUsed = "new", VanReleaseYear = 2019, VanColor = "red", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "gasoline", IsElectricVan = true, Brand_id = 4 };

            RentVan RentVan1 = new RentVan() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstVan = false, Van_id = 1 };
            RentVan RentVan2 = new RentVan() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstVan = true, Van_id = 8 };
            RentVan RentVan3 = new RentVan() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstVan = true, Van_id = 14 };
            RentVan RentVan4 = new RentVan() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstVan = false, Van_id = 4 };


            modelBuilder.Entity<Brand>().HasData(Brand1, Brand2, Brand3, Brand4);
            modelBuilder.Entity<Models.Van>().HasData(Van1, Van2, Van3, Van4, Van5, Van6, Van7, Van8, Van9, Van10, Van11, Van12, Van13, Van14, Van15, Van16);
            modelBuilder.Entity<RentVan>().HasData(RentVan1, RentVan2, RentVan3, RentVan4);
            //VanDBContext vanDBContext = new VanDBContext();
            //vanDBContext.Add(Brand1);
            //vanDBContext.SaveChanges();

        }
    }
}
