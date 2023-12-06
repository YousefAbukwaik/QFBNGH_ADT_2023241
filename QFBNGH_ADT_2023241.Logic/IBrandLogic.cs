using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QFBNGH_ADT_2023241.Models;

namespace QFBNGH_ADT_2023241.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand obj);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand obj);
        void Delete(int id);


        IEnumerable<Brand> GetBrandWithSanya();
        IEnumerable<Brand> GetBrandWhereGenderIsMale();
    }
}
