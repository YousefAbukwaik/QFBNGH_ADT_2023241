using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QFBNGH_ADT_2023241.Models
{
    public class Van
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VanName { get; set; }
        public string VanType { get; set; }
        public int VanPrice { get; set; }
        public string NewOrUsed { get; set; }
        public int VanReleaseYear { get; set; }
        public string VanColor { get; set; }
        public int VanSeatNumber { get; set; }
        public bool IsLeftWheel { get; set; }
        public string FuelType { get; set; }
        public bool IsElectricVan { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<RentVan> RentVan { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof(Brand))]
        public int? Brand_id { get; set; }

        public Van()
        {
            RentVan = new HashSet<RentVan>();
        }

    }
}
