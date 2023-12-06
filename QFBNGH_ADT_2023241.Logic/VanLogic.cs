using QFBNGH_ADT_2023241.Models;
using QFBNGH_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QFBNGH_ADT_2023241.Logic
{
    public class VanLogic : IVanLogic
    {
        IRepository<Van> VanRepo;

        //DP injection
        public VanLogic(IRepository<Van> VanRepo)
        {
            this.VanRepo = VanRepo;
        }

        public void Create(Van obj)
        {

            VanRepo.Create(obj);
        }

        public void Delete(int id)
        {
            VanRepo.Delete(id);
        }

        public Van Read(int id)
        {

            return VanRepo.Read(id);

        }

        public IQueryable<Van> ReadAll()
        {
            return VanRepo.ReadAll();
        }

        public void Update(Van obj)
        {
            VanRepo.Update(obj);
        }


    }
}
