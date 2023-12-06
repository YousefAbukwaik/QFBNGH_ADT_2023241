
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFBNGH_ADT_2023241.Models;

namespace QFBNGH_ADT_2023241.Logic
{
    public interface IRentVanLogic
    {

        void Create(RentVan obj);
        RentVan Read(int id);
        IQueryable<RentVan> ReadAll();
        void Update(RentVan obj);
        void Delete(int id);


        IEnumerable<RentVan> GetRentVanAtBMWBrand();
        IEnumerable<RentVan> GetRentVanRepoWhereVanPriceIsOver4();
        IEnumerable<RentVan> GetRentVanReposWhereVanModelNameIsBMWVan();
        IEnumerable<RentVan> GetRentVanWhereVanModelNameIsBMWVan2();


    }
}
