using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace QFBNGH_ADT_2023241.Models
{
    public class RentVan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string BuyerName { get; set; }
        public int BuyDate { get; set; }
        public string BuyerGender { get; set; }
        public bool IsFirstVan { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Van Van { get; set; }
        [ForeignKey(nameof(Van))]
        public int? Van_id { get; set; }

    }
}
