using QFBNGH_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QFBNGH_ADT_2023241.Repository
{
    public class VanRepository : Repository<Van>
    {
        public VanRepository(VanDBContext hpdb) : base(hpdb)
        {
        }
        public override Van Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(Van obj)
        {

            var oldVan = Read(obj.Id);
            oldVan.Id = obj.Id;
            oldVan.VanName = obj.VanName;
            oldVan.VanType = obj.VanType;
            oldVan.VanPrice = obj.VanPrice;
            oldVan.VanReleaseYear = obj.VanReleaseYear;
            oldVan.VanColor = obj.VanColor;
            oldVan.VanSeatNumber = obj.VanSeatNumber;
            oldVan.IsLeftWheel = obj.IsLeftWheel;
            oldVan.FuelType = obj.FuelType;
            oldVan.IsElectricVan = obj.IsElectricVan;
            oldVan.Brand_id = obj.Brand_id;
            db.SaveChanges();

        }
        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
