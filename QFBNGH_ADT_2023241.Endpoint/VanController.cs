using QFBNGH_ADT_2023241.Logic;
using QFBNGH_ADT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QFBNGH_ADT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VanController : ControllerBase
    {
        IVanLogic vanlogic;

        public VanController(IVanLogic vanlogic)
        {
            this.vanlogic = vanlogic;
        }

        [HttpGet]
        public IEnumerable<Van> Get()
        {
            return vanlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Van Get(int id)
        {
            return vanlogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Van value)
        {
            vanlogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Van value)
        {
            vanlogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var CarToDelete = this.vanlogic.Read(id);
            vanlogic.Delete(id);

        }
    }
}
