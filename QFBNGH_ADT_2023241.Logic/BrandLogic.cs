using QFBNGH_ADT_2023241.Models;
using QFBNGH_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace QFBNGH_ADT_2023241.Logic
{
    public class BrandLogic : IBrandLogic
    {



        IRepository<Brand> brandRepo;
        IRepository<Van> vanRepo;
        IRepository<RentVan> rentvanRepo;

      

        public BrandLogic(IRepository<Brand> brandRepo, IRepository<Van> vanRepo, IRepository<RentVan> rentvanRepo)
        {
            this.brandRepo = brandRepo;
            this.vanRepo = vanRepo;
           this.rentvanRepo = rentvanRepo;
        }

        public void Create(Brand obj)
        {

            brandRepo.Create(obj);
        }

        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }

        public Brand Read(int id)
        {

            return brandRepo.Read(id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }

        public void Update(Brand obj)
        {
            brandRepo.Update(obj);
        }

        public IEnumerable<Brand> GetBrandWithSanya()
        {
            var q = from RentVans in rentvanRepo.ReadAll()
                    join Vans in vanRepo.ReadAll()
                    on RentVans.Van_id equals Vans.Id
                    join Brands in brandRepo.ReadAll()
                    on Vans.Brand_id equals Brands.Id
                    where RentVans.BuyerName == "Sanya"
                    select Brands;
            return q;
        }

        public IEnumerable<Brand> GetBrandWhereGenderIsMale()
        {
            var q = from RentVans in rentvanRepo.ReadAll()
                    join Vans in vanRepo.ReadAll()
                    on RentVans.Van_id equals Vans.Id
                    join Brands in brandRepo.ReadAll()
                    on Vans.Brand_id equals Brands.Id
                    where RentVans.BuyerGender == "male"
                    select Brands;
            return q;
        }

    }
}