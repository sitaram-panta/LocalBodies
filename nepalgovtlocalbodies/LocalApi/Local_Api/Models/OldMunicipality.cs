using Local_Api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Local_Api.Models
{
    public class OldMunicipality
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String OldMunicipalityTitle { get; set; } =string.Empty;
        public string OldMunicipalityCode { get; set; } = string.Empty;
        [ForeignKey ("OldDistrict")]
        public int OldDistrictId { get; set; }
        public Types OldMunicipalityType { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public virtual OldDistrict? OldDistrict { get; set; }
    }
}
