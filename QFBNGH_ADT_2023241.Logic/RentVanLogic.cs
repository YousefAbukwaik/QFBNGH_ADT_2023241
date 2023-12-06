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
    public class RentVanLogic : IRentVanLogic
    {

        IRepository<Brand> BrandRepo;
        IRepository<Van> VanRepo;
        IRepository<RentVan> RentVanRepo;
        public RentVanLogic(IRepository<Brand> BrandRepo, IRepository<Van> VanRepo, IRepository<RentVan> RentVanRepo)
        {
            this.BrandRepo = BrandRepo;
            this.VanRepo = VanRepo;
            this.RentVanRepo = RentVanRepo;
        }



        public void Create(RentVan obj)
        {

            RentVanRepo.Create(obj);
        }

        public void Delete(int id)
        {
            RentVanRepo.Delete(id);
        }

        public RentVan Read(int id)
        {

            return RentVanRepo.Read(id);

        }

        public IQueryable<RentVan> ReadAll()
        {
            return RentVanRepo.ReadAll();
        }

        public void Update(RentVan obj)
        {
            RentVanRepo.Update(obj);
        }
        public IEnumerable<RentVan> GetRentVanAtBMWBrand()
        {


            var q = from RentVan in RentVanRepo.ReadAll()
                    join Van in VanRepo.ReadAll()
                    on RentVan.Van_id equals Van.Id
                    join Brands in BrandRepo.ReadAll()
                    on Van.Brand_id equals Brands.Id
                    where Brands.BrandName == "BMW"
                    select RentVan;

            return q.ToList();
        }
        public IEnumerable<RentVan> GetRentVanRepoWhereVanPriceIsOver4()
        {
            var q = from RentVan in RentVanRepo.ReadAll()
                    join Van in VanRepo.ReadAll()
                    on RentVan.Van_id equals Van.Id
                    where Van.VanPrice > 4
                    select RentVan;
            return q;
        }

        public IEnumerable<RentVan> GetRentVanReposWhereVanModelNameIsBMWVan()
        {
            var q = from RentVan in RentVanRepo.ReadAll()
                    join Van in VanRepo.ReadAll()
                    on RentVan.Van_id equals Van.Id
                    where Van.VanName == "BMW Van1"
                    select RentVan;
            return q;
        }

        public IEnumerable<RentVan> GetRentVanWhereVanModelNameIsBMWVan2()
        {
            var q = from RentVan in RentVanRepo.ReadAll()
                    join Van in VanRepo.ReadAll()
                    on RentVan.Van_id equals Van.Id
                    where Van.VanName == "BMW Van1"
                    select RentVan;
            return q;
        }
    }
}