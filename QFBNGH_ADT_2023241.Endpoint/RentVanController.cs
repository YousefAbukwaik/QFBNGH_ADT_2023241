using QFBNGH_ADT_2023241.Logic;
using QFBNGH_ADT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;


namespace QFBNGH_ADT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentVanController : ControllerBase
    {
        IRentVanLogic rentvanlogic;

        public RentVanController(IRentVanLogic rentvanlogic)
        {
            this.rentvanlogic = rentvanlogic;
        }


        [HttpGet]
        public IEnumerable<RentVan> Get()
        {
            return rentvanlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public RentVan Get(int id)
        {
            return rentvanlogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] RentVan value)
        {
            rentvanlogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] RentVan value)
        {
            rentvanlogic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var RentCarToDelete = this.rentvanlogic.Read(id);
            rentvanlogic.Delete(id);
        }
    }
}
