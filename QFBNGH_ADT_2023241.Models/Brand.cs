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
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string BrandName { get; set; }
        public string BrandCountry { get; set; }
        public int BrandYear { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Van> Van { get; set; }
        public List<Van> Vans { get; set; }

        public Brand()
        {
            Van = new HashSet<Van>();
        }

    }
}
