using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Local_Api.Models
{
    public class Zone
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        public string ZoneTitle { get; set;}=string.Empty;
        public string ZoneCode { get; set;} = string.Empty;
        public bool Status { get; set; }
        [JsonIgnore]
        public virtual ICollection<OldDistrict>? OldDistricts { get; set; }
    }
} 
