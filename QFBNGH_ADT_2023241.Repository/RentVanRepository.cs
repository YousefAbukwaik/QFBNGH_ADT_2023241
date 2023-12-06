using QFBNGH_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFBNGH_ADT_2023241.Repository
{
    public class RentVanRepository : Repository<RentVan>
    {
        public RentVanRepository(VanDBContext hpdb) : base(hpdb)
        {
        }

        public override RentVan Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(RentVan obj)
        {
            var oldRentVan = Read(obj.Id);
            oldRentVan.Id = obj.Id;
            oldRentVan.BuyerName = obj.BuyerName;
            oldRentVan.BuyDate = obj.BuyDate;
            oldRentVan.BuyerGender = obj.BuyerGender;
            oldRentVan.IsFirstVan = obj.IsFirstVan;
            oldRentVan.Van_id = obj.Van_id;
            db.SaveChanges();
        }
        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }


    }
}
