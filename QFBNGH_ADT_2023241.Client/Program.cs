using ConsoleTools;
using QFBNGH_ADT_2023241.Logic;
using QFBNGH_ADT_2023241.Models;
using QFBNGH_ADT_2023241.Repository;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFBNGH_ADT_2023241.Client
{
    public class Program
    {

        //static public VanDBContext vanDBContext = new VanDBContext();
        public static RestService rserv = new RestService("http://localhost:21071");
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);


            var menu = new ConsoleMenu()
               .Add("CRUD methods", () => CrudMenu())
               .Add("non-CRUD methods", () => NonCrudMenu())
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();

        }

        private static void CrudMenu()
        {


            var menu = new ConsoleMenu()
                .Add("Create element", CreatePreMenu)
                .Add("Get one element", ReadPreMenu)
                .Add("Get all element", ReadAllPreMenu)
                .Add("Update element", UpdatePreMenu)
                .Add("Delete element", DeletePreMenu)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();

        }
        private static void NonCrudMenu()
        {
            var menu = new ConsoleMenu()
               .Add("Get RentVan at the BMW Brand", GetRentVanAtBMWBrand)
               .Add("Get RentVan where the Van price is over 4K$", GetRentVanWhereVanPriceIsOver4)
               .Add("Get RentVan where the Van name is BMW Van1", GetRentVanWhereVanModelNameIsBMWVan1)
               .Add("Get Brands where remters name is Sanya", GetBrandWithSanya)
               .Add("Get Brands where renter is male", GetBrandWhereGenderIsMale)
               .Add("Exit", ConsoleMenu.Close);
            menu.Show();

        }

        private static void PreMenu(Action RentVan, Action Van, Action Brand)
        {
            var menu = new ConsoleMenu()
                .Add("RentVan", RentVan)
                .Add("Van", Van)
                .Add("Brand", Brand)
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
        //-------------------------------------------------------------------------------------------------------------CRUD------------------------------------------------

        //---------------------Create-------------------------
        private static void CreatePreMenu()
        {
            PreMenu(CreateRentVan, CreateVan, CreateBrand);
        }

        private static void CreateBrand()
        {
            Console.WriteLine("BrandName: ");
            string brandname = Console.ReadLine();
            Console.WriteLine("Age:");
            int brandyear = int.Parse(Console.ReadLine());
            rserv.Post<Brand>(new Brand() { BrandName = brandname, BrandYear = brandyear }, "Brand");
        }

        private static void CreateVan()
        {
            Console.WriteLine("Name: ");
            string vanname = Console.ReadLine();
            Console.WriteLine("Type:");
            string vantype = Console.ReadLine();
            Console.WriteLine("Brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            rserv.Post<Van>(new Van() { VanName = vanname, VanType = vantype, Brand_id = brandid }, "Van");

        }

        private static void CreateRentVan()
        {
            Console.WriteLine("Name: ");
            string buyername = Console.ReadLine();
            Console.WriteLine("Role name:");
            string buyergender = Console.ReadLine();
            Console.WriteLine("Van id: ");
            int vanid = int.Parse(Console.ReadLine());
            rserv.Post<RentVan>(new RentVan() { BuyerName = buyername, BuyerGender = buyergender, Van_id = vanid }, "RentVan");
        }

        //---------------------END-Create-------------------





        //---------------------Read------------------------
        private static void ReadPreMenu()
        {
            PreMenu(ReadRentVan, ReadVan, ReadBrand);
        }

        private static void ReadBrand()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getBrand = rserv.Get<Brand>(id, "Brand");
            Console.WriteLine($"Id: {getBrand.Id}, BrandName: {getBrand.BrandName}, BrandYear: {getBrand.BrandYear}");
            Console.ReadLine();

        }

        private static void ReadVan()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getvan = rserv.Get<Van>(id, "Van");
            Console.WriteLine($"Id: {getvan.Id}, VanName: {getvan.VanName}, VanType: {getvan.VanType}, BrandId: {getvan.Brand_id}");
            Console.ReadLine();
        }

        private static void ReadRentVan()
        {
            Console.WriteLine("Search for desired with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            var getRentVan = rserv.Get<RentVan>(id, "RentVan");
            Console.WriteLine($"Id: {getRentVan.Id}, BuyerName: {getRentVan.BuyerName}, BuyerGender: {getRentVan.BuyerGender}, MotorId: {getRentVan.Van_id}");
            Console.ReadLine();
        }

        //---------------------END-Read-------------------





        //----------------------ReadAll----------------------
        private static void ReadAllPreMenu()
        {
            PreMenu(PrintAllRentVan, PrintAllVan, PrintAllBrands);
        }

        private static void PrintAllRentVan()
        {
            var rentVan = rserv.Get<RentVan>("RentVan");
            Console.WriteLine("-------------RentVan-------------");
            RentVanToConsole(rentVan);
            Console.ReadLine();
        }
        private static void PrintAllVan()
        {
            var vans = rserv.Get<Van>("Van");
            Console.WriteLine("-------------Vans-------------");
            VanToConsole(vans);
            Console.ReadLine();
        }
        private static void PrintAllBrands()
        {
            var Brands = rserv.Get<Brand>("Brand");
            Console.WriteLine("-------------Brands-------------");
            BrandToConsole(Brands);
            Console.ReadLine();
        }
        //---------------END-ReadAll-------------------





        //-----------------Update-------------------
        private static void UpdatePreMenu()
        {
            PreMenu(UpdateRentVan, UpdateVan, UpdateBrand);
        }

        private static void UpdateBrand()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("BrandName: ");
            string BrandName = Console.ReadLine();
            Console.WriteLine("BrandYear:");
            int brandyear = int.Parse(Console.ReadLine());
            Brand input = new Brand() { Id = id, BrandName = BrandName, BrandYear = brandyear };
            rserv.Put(input, "Brand");
        }

        private static void UpdateVan()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("VanName: ");
            string vanname = Console.ReadLine();
            Console.WriteLine("VanType:");
            string vantype = Console.ReadLine();
            Console.WriteLine("Brand id: ");
            int brandid = int.Parse(Console.ReadLine());
            Van input = new Van() { Id = id, VanName = vanname, VanType = vantype, Brand_id = brandid };
            rserv.Put(input, "Van");
        }

        private static void UpdateRentVan()
        {
            Console.WriteLine("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("BuyerName: ");
            string name = Console.ReadLine();
            Console.WriteLine("BuyDate:");
            int buydate = int.Parse(Console.ReadLine());
            Console.WriteLine("Car id: ");
            int vanid = int.Parse(Console.ReadLine());
            RentVan input = new RentVan() { Id = id, BuyerName = name, BuyDate = buydate, Van_id = vanid };
            rserv.Put(input, "RentVan");
        }

        //-----------------END-Update-------------





        //-----------------Delete--------------
        private static void DeletePreMenu()
        {
            PreMenu(DeleteRentVan, DeleteVan, DeleteBrand);
        }

        private static void DeleteBrand()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Brand");
        }

        private static void DeleteVan()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "Van");
        }

        private static void DeleteRentVan()
        {
            Console.WriteLine("Delete element with an Id of: ");
            int id = int.Parse(Console.ReadLine());
            rserv.Delete(id, "RentVan");
        }

        //-------------------END-Delete----------













        ////-------------------------------------------------------------------------------------------------------------non-CRUD------------------------------------------------

        private static void GetRentVanAtBMWBrand()
        {
            var output = rserv.Get<RentVan>("stat/GetRentVanAtBMWBrand");

            RentVanToConsole(output);
            Console.ReadLine();
        }
        private static void GetRentVanWhereVanPriceIsOver4()
        {
            var output = rserv.Get<RentVan>("stat/GetRentVanWhereVanPriceIsOver4");
            RentVanToConsole(output);
            Console.ReadLine();
        }

        private static void GetRentVanWhereVanModelNameIsBMWVan1()
        {
            var output = rserv.Get<RentVan>("stat/GetRentVanWhereVanModelNameIsBMWVan1");
            RentVanToConsole(output);
            Console.ReadLine();
        }
        private static void GetRentVanWhereVanModelNameIsBMWVan()
        {
            var output = rserv.Get<Brand>("stat/GetRentVanWhereVanModelNameIsBMWVan");
            BrandToConsole(output);
            Console.ReadLine();
        }
        private static void GetBrandWithSanya()
        {
            var output = rserv.Get<Brand>("stat/GetBrandWithSanya");
            BrandToConsole(output);
            Console.ReadLine();
        }


        private static void GetBrandWhereGenderIsMale()
        {
            var output = rserv.Get<Brand>("stat/GetBrandWhereGenderIsMale");
            BrandToConsole(output);
            Console.ReadLine();
        }












        ////-------------------------------------------------------------------------------------------------------------ToConsole------------------------------------------------
        private static void RentVanToConsole(IEnumerable<RentVan> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, BuyDate: {item.BuyDate}, BuyerName: {item.BuyerName}, VanId: {item.Van_id}");
            }
        }
        private static void VanToConsole(IEnumerable<Van> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, MotorName: {item.VanName}, MotorType: {item.VanType}, BrandId: {item.Brand_id}");
            }
        }
        private static void BrandToConsole(IEnumerable<Brand> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Id: {item.Id}, BrandName: {item.BrandName}, BrandYear: {item.BrandYear}");
            }
        }
    }
}

    





