using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFBNGH_ADT_2023241.Models;

namespace QFBNGH_ADT_2023241.Logic
{
    public interface IVanLogic
    {
        //CRUD
        void Create(Van obj);
        Van Read(int id);
        IQueryable<Van> ReadAll();
        void Update(Van obj);
        void Delete(int id);
    }
}
