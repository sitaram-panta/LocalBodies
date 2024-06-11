using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Local_Api.Models
{
    public class OldDistrict
    {
        public int Id { get; set; }
        [Required]
        public string OldDistrictTitle { get; set; } =string.Empty;
        public string OldDistrictCode { get; set; } =string.Empty;
        public int ZoneId { get; set; }
        public bool Status { get; set; }
        [ForeignKey("ZoneId"), JsonIgnore]
        public virtual Zone? Zone { get; set; }
        [JsonIgnore]
        public virtual ICollection<OldMunicipality>? OldMunicipalities { get; set; }
    }
}
