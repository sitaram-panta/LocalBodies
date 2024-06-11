using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Local_Api.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DistrictTitle { get; set; } = string.Empty;
        public string DistrictCode { get; set; } = string.Empty;
        [ForeignKey ("Province")]
        public int ProvinceId { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public virtual Province? Province { get; set; }
        [JsonIgnore]
        public virtual ICollection<Municipality>? Municipalities { get; set; }
    }
}
