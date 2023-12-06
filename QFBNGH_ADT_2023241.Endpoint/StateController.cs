using QFBNGH_ADT_2023241.Logic;
using QFBNGH_ADT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QFBNGH_ADT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IRentVanLogic rentvanlogic;
        IBrandLogic brandlogic;

        public StatController(IRentVanLogic rentvanlogic, IBrandLogic brandlogic)
        {
            this.rentvanlogic = rentvanlogic;
            this.brandlogic = brandlogic;
        }

        [HttpGet]
        public IEnumerable<RentVan> GetRentVanReposAtBMWBrand()
        {
            return rentvanlogic.GetRentVanAtBMWBrand();
        }
        [HttpGet]
        public IEnumerable<RentVan> GetRentVanRepoWhereVanPriceIsOver4()
        {
            return rentvanlogic.GetRentVanRepoWhereVanPriceIsOver4();
        }
        [HttpGet]
        public IEnumerable<RentVan> GetRentVanReposWhereVanModelNameIsBMWVan()
        {
            return rentvanlogic.GetRentVanReposWhereVanModelNameIsBMWVan();
        }

        [HttpGet]
        public IEnumerable<Brand> GetBrandWithSanya()
        {
            return brandlogic.GetBrandWithSanya();
        }
        [HttpGet]
        public IEnumerable<Brand> GetBrandWhereGenderIsMale()
        {
            return brandlogic.GetBrandWhereGenderIsMale();
        }
    }
}
