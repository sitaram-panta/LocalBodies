using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Local_Api.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProvinceTitle { get; set; }= string.Empty;
        public string ProvinceCode { get; set; }= string.Empty;
        public bool Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<District>? Districts { get; set; }
    }
}

