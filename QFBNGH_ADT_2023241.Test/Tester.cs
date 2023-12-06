using QFBNGH_ADT_2023241.Models;
using QFBNGH_ADT_2023241.Logic;
using QFBNGH_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace QFBNGH_ADT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        RentVanLogic rentvanlogic;
        VanLogic vanlogic;
        BrandLogic brandlogic;

        [SetUp]
        public void Setup()
        {
            Mock<IRepository<RentVan>> mockRentVanRepo = new Mock<IRepository<RentVan>>();
            Mock<IRepository<Van>> mockVanRepo = new Mock<IRepository<Van>>();
            Mock<IRepository<Brand>> mockBrandRepo = new Mock<IRepository<Brand>>();

            mockRentVanRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                new RentVan()
                {
                    Id = 1,
                    BuyerName = "Tanya",
                    BuyDate = 2000,
                    BuyerGender = "female",
                    IsFirstVan = false,
                    Van_id = 1,
                });

            mockRentVanRepo.Setup(x => x.ReadAll()).Returns(FakeRentVanObject);
            mockVanRepo.Setup(x => x.ReadAll()).Returns(FakeVanObject);
            mockBrandRepo.Setup(x => x.ReadAll()).Returns(FakeBrandObject);


            rentvanlogic = new RentVanLogic(mockBrandRepo.Object, mockVanRepo.Object, mockRentVanRepo.Object);
            brandlogic = new BrandLogic(mockBrandRepo.Object, mockVanRepo.Object, mockRentVanRepo.Object);
            vanlogic = new VanLogic(mockVanRepo.Object);

        }

        public void lablab()
        {

        }


        [Test]
        public void GetOneRentVanBuyerName()
        {
            Assert.That(rentvanlogic.Read(1).BuyerName, Is.EqualTo("Tanya"));
        }

        [Test]
        public void GetOneRentVanBuyDate()
        {
            Assert.That(rentvanlogic.Read(1).BuyDate, Is.EqualTo(2000));
        }

        [Test]
        public void GetOneRentVanBuyerGender()
        {
            Assert.That(rentvanlogic.Read(1).BuyerGender, Is.EqualTo("female"));
        }

        [Test]
        public void GetAllRentVan_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.rentvanlogic.ReadAll().Count, Is.EqualTo(4));
        }

        [Test]
        public void GetRentVanAtTokyo_ReturnsCorrectInstance()
        {
            Assert.That(rentvanlogic.GetRentVanAtBMWBrand().Count, Is.EqualTo(4));
        }


        [Test]
        public void GetRentVanWhereModelNameBMW1_ReturnsCorrectInstance()
        {
            Assert.That(rentvanlogic.GetRentVanReposWhereVanModelNameIsBMWVan().First().Van.IsElectricVan, Is.EqualTo(true));
        }

        [Test]
        public void GetRentVanWhereModelNameBMW2_ReturnsCorrectInstance()
        {
            Assert.That(rentvanlogic.GetRentVanWhereVanModelNameIsBMWVan2().First().Van.IsElectricVan, Is.EqualTo(true));
        }

        [Test]
        public void GetBrandName()
        {
            Assert.That(brandlogic.GetBrandWithSanya().Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetOneRentVanIsFirstVan()
        {
            Assert.That(rentvanlogic.Read(1).IsFirstVan, Is.EqualTo(false));
        }

        [Test]
        public void GetOneRentVanVan_id()
        {
            Assert.That(rentvanlogic.Read(1).Van_id, Is.EqualTo(1));
        }


        private IQueryable<RentVan> FakeRentVanObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "BMW", BrandCountry = "Japan", BrandYear = 2001 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 2005 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 2010 };


            Brand1.Vans = new List<Van>();
            Brand2.Vans = new List<Van>();
            Brand3.Vans = new List<Van>();

            // -------------------------------------------------------------------------------------------------------

            Van Van1 = new Van() { Id = 1, VanName = "BMW Van1", VanType = "Swift", VanPrice = 1, NewOrUsed = "new", VanReleaseYear = 2000, VanColor = "black", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = true, Brand_id = 1 };
            Van Van2 = new Van() { Id = 2, VanName = "BMW Van2", VanType = "Ignis", VanPrice = 3, NewOrUsed = "new", VanReleaseYear = 2005, VanColor = "white", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 1 };
            Van Van3 = new Van() { Id = 3, VanName = "BMW Van3", VanType = "Swift", VanPrice = 15, NewOrUsed = "used", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = false, Brand_id = 1 };
            Van Van4 = new Van() { Id = 4, VanName = "BMW Van4", VanType = "Vitara", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 1990, VanColor = "green", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricVan = false, Brand_id = 1 };
            Van Van5 = new Van() { Id = 5, VanName = "Toyota Van1", VanType = "Yaris", VanPrice = 4, NewOrUsed = "new", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 2 };
            Van Van6 = new Van() { Id = 6, VanName = "Toyota Van2", VanType = "Corolla", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 2000, VanColor = "green", VanSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = false, Brand_id = 2 };


            Van1.Brand = Brand1;
            Van2.Brand = Brand1;
            Van3.Brand = Brand2;
            Van4.Brand = Brand2;
            Van5.Brand = Brand3;
            Van6.Brand = Brand3;

            Van1.Brand_id = Brand1.Id; Brand1.Vans.Add(Van1);
            Van2.Brand_id = Brand1.Id; Brand1.Vans.Add(Van2);
            Van3.Brand_id = Brand2.Id; Brand2.Vans.Add(Van3);
            Van4.Brand_id = Brand2.Id; Brand2.Vans.Add(Van4);
            Van5.Brand_id = Brand3.Id; Brand3.Vans.Add(Van5);
            Van6.Brand_id = Brand3.Id; Brand3.Vans.Add(Van6);

            Van1.RentVan = new List<RentVan>();
            Van2.RentVan = new List<RentVan>();
            Van3.RentVan = new List<RentVan>();
            Van4.RentVan = new List<RentVan>();
            Van5.RentVan = new List<RentVan>();
            Van6.RentVan = new List<RentVan>();

            // -------------------------------------------------------------------------------------------------------


            RentVan RentVan1 = new RentVan() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstVan = false, Van_id = 1 };
            RentVan RentVan2 = new RentVan() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstVan = true, Van_id = 2 };
            RentVan RentVan3 = new RentVan() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstVan = true, Van_id = 3 };
            RentVan RentVan4 = new RentVan() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstVan = false, Van_id = 4 };

            RentVan1.Van = Van1;
            RentVan2.Van = Van1;
            RentVan3.Van = Van2;
            RentVan4.Van = Van2;


            RentVan1.Van_id = Van1.Id; Van1.RentVan.Add(RentVan1);
            RentVan2.Van_id = Van1.Id; Van1.RentVan.Add(RentVan2);
            RentVan3.Van_id = Van2.Id; Van2.RentVan.Add(RentVan3);
            RentVan4.Van_id = Van2.Id; Van2.RentVan.Add(RentVan4);


            // -------------------------------------------------------------------------------------------------------

            List<RentVan> RentVan = new List<RentVan>();
            RentVan.Add(RentVan1);
            RentVan.Add(RentVan2);
            RentVan.Add(RentVan3);
            RentVan.Add(RentVan4);

            return RentVan.AsQueryable();
        }

        private IQueryable<Van> FakeVanObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "Suzuki", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };

            Brand1.Vans = new List<Van>();
            Brand2.Vans = new List<Van>();
            Brand3.Vans = new List<Van>();

            // -------------------------------------------------------------------------------------------------------

            Van Van1 = new Van() { Id = 1, VanName = "BMW Van1", VanType = "Swift", VanPrice = 1, NewOrUsed = "new", VanReleaseYear = 2000, VanColor = "black", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = true, Brand_id = 1 };
            Van Van2 = new Van() { Id = 2, VanName = "BMW Van2", VanType = "Ignis", VanPrice = 3, NewOrUsed = "new", VanReleaseYear = 2005, VanColor = "white", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 1 };
            Van Van3 = new Van() { Id = 3, VanName = "BMW Van3", VanType = "Swift", VanPrice = 15, NewOrUsed = "used", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = false, Brand_id = 1 };
            Van Van4 = new Van() { Id = 4, VanName = "Suzuki Van4", VanType = "Vitara", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 1990, VanColor = "green", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricVan = false, Brand_id = 1 };
            Van Van5 = new Van() { Id = 5, VanName = "Toyota Van1", VanType = "Yaris", VanPrice = 4, NewOrUsed = "new", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 2 };
            Van Van6 = new Van() { Id = 6, VanName = "Toyota Van2", VanType = "Corolla", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 2000, VanColor = "green", VanSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = false, Brand_id = 2 };

            Van1.Brand = Brand1;
            Van2.Brand = Brand1;
            Van3.Brand = Brand2;
            Van4.Brand = Brand2;
            Van5.Brand = Brand3;
            Van6.Brand = Brand3;

            Van1.Brand_id = Brand1.Id; Brand1.Vans.Add(Van1);
            Van2.Brand_id = Brand1.Id; Brand1.Vans.Add(Van2);
            Van3.Brand_id = Brand2.Id; Brand2.Vans.Add(Van3);
            Van4.Brand_id = Brand2.Id; Brand2.Vans.Add(Van4);
            Van5.Brand_id = Brand3.Id; Brand3.Vans.Add(Van5);
            Van6.Brand_id = Brand3.Id; Brand3.Vans.Add(Van6);

            Van1.RentVan = new List<RentVan>();
            Van2.RentVan = new List<RentVan>();
            Van3.RentVan = new List<RentVan>();
            Van4.RentVan = new List<RentVan>();
            Van5.RentVan = new List<RentVan>();
            Van6.RentVan = new List<RentVan>();

            // -------------------------------------------------------------------------------------------------------

            RentVan RentVan1 = new RentVan() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstVan = false, Van_id = 1 };
            RentVan RentVan2 = new RentVan() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstVan = true, Van_id = 2 };
            RentVan RentVan3 = new RentVan() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstVan = true, Van_id = 3 };
            RentVan RentVan4 = new RentVan() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstVan = false, Van_id = 4 };

            RentVan1.Van = Van1;
            RentVan2.Van = Van1;
            RentVan3.Van = Van2;
            RentVan4.Van = Van2;


            RentVan1.Van_id = Van1.Id; Van1.RentVan.Add(RentVan1);
            RentVan2.Van_id = Van1.Id; Van1.RentVan.Add(RentVan2);
            RentVan3.Van_id = Van2.Id; Van2.RentVan.Add(RentVan3);
            RentVan4.Van_id = Van2.Id; Van2.RentVan.Add(RentVan4);
            // -------------------------------------------------------------------------------------------------------

            List<Van> Vans = new List<Van>();
            Vans.Add(Van1);
            Vans.Add(Van2);
            Vans.Add(Van3);
            Vans.Add(Van4);
            Vans.Add(Van5);
            Vans.Add(Van6);
            return Vans.AsQueryable();

        }
        private IQueryable<Brand> FakeBrandObject()
        {
            Brand Brand1 = new Brand() { Id = 1, BrandName = "BMW", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand2 = new Brand() { Id = 2, BrandName = "Toyota", BrandCountry = "Japan", BrandYear = 1909 };
            Brand Brand3 = new Brand() { Id = 3, BrandName = "Ferrari", BrandCountry = "Italy", BrandYear = 1941 };


            Brand1.Vans = new List<Van>();
            Brand2.Vans = new List<Van>();
            Brand3.Vans = new List<Van>();

            // -------------------------------------------------------------------------------------------------------
            Van Van1 = new Van() { Id = 1, VanName = "BMW Van1", VanType = "Swift", VanPrice = 1, NewOrUsed = "new", VanReleaseYear = 2000, VanColor = "black", VanSeatNumber = 4, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = true, Brand_id = 1 };
            Van Van2 = new Van() { Id = 2, VanName = "BMW Van2", VanType = "Ignis", VanPrice = 3, NewOrUsed = "new", VanReleaseYear = 2005, VanColor = "white", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 1 };
            Van Van3 = new Van() { Id = 3, VanName = "BMW Van3", VanType = "Swift", VanPrice = 15, NewOrUsed = "used", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 6, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = false, Brand_id = 1 };
            Van Van4 = new Van() { Id = 4, VanName = "BMW Van4", VanType = "Vitara", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 1990, VanColor = "green", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "diesel", IsElectricVan = false, Brand_id = 1 };
            Van Van5 = new Van() { Id = 5, VanName = "Toyota Van1", VanType = "Yaris", VanPrice = 4, NewOrUsed = "new", VanReleaseYear = 2020, VanColor = "red", VanSeatNumber = 4, IsLeftWheel = false, FuelType = "gasoline", IsElectricVan = true, Brand_id = 2 };
            Van Van6 = new Van() { Id = 6, VanName = "Toyota Van2", VanType = "Corolla", VanPrice = 1, NewOrUsed = "used", VanReleaseYear = 2000, VanColor = "green", VanSeatNumber = 3, IsLeftWheel = true, FuelType = "diesel", IsElectricVan = false, Brand_id = 2 };

            Van1.Brand = Brand1;
            Van2.Brand = Brand1;
            Van3.Brand = Brand2;
            Van4.Brand = Brand2;
            Van5.Brand = Brand3;
            Van6.Brand = Brand3;

            Van1.Brand_id = Brand1.Id; Brand1.Vans.Add(Van1);
            Van2.Brand_id = Brand1.Id; Brand1.Vans.Add(Van2);
            Van3.Brand_id = Brand2.Id; Brand2.Vans.Add(Van3);
            Van4.Brand_id = Brand2.Id; Brand2.Vans.Add(Van4);
            Van5.Brand_id = Brand3.Id; Brand3.Vans.Add(Van5);
            Van6.Brand_id = Brand3.Id; Brand3.Vans.Add(Van6);

            Van1.RentVan = new List<RentVan>();
            Van2.RentVan = new List<RentVan>();
            Van3.RentVan = new List<RentVan>();
            Van4.RentVan = new List<RentVan>();
            Van5.RentVan = new List<RentVan>();
            Van6.RentVan = new List<RentVan>();

            // -------------------------------------------------------------------------------------------------------

            RentVan RentVan1 = new RentVan() { Id = 1, BuyerName = "Sanya", BuyDate = 2020, BuyerGender = "male", IsFirstVan = false, Van_id = 1 };
            RentVan RentVan2 = new RentVan() { Id = 2, BuyerName = "Erik", BuyDate = 2022, BuyerGender = "male", IsFirstVan = true, Van_id = 2 };
            RentVan RentVan3 = new RentVan() { Id = 3, BuyerName = "Evelin", BuyDate = 2022, BuyerGender = "female", IsFirstVan = true, Van_id = 3 };
            RentVan RentVan4 = new RentVan() { Id = 4, BuyerName = "Erzsi", BuyDate = 2018, BuyerGender = "female", IsFirstVan = false, Van_id = 4 };

            RentVan1.Van = Van1;
            RentVan2.Van = Van1;
            RentVan3.Van = Van2;
            RentVan4.Van = Van2;


            RentVan1.Van_id = Van1.Id; Van1.RentVan.Add(RentVan1);
            RentVan2.Van_id = Van1.Id; Van1.RentVan.Add(RentVan2);
            RentVan3.Van_id = Van2.Id; Van2.RentVan.Add(RentVan3);
            RentVan4.Van_id = Van2.Id; Van2.RentVan.Add(RentVan4);


            List<Brand> Brands = new List<Brand>();
            Brands.Add(Brand1);
            Brands.Add(Brand2);
            Brands.Add(Brand3);
            return Brands.AsQueryable();

        }
    }
}
