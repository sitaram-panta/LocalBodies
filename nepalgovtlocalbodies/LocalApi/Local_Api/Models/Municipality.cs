using Local_Api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Type = Local_Api.Enums.Types;

namespace Local_Api.Models
{
    public class Municipality
    {
        [Key]
        public int Id { get; set; }
        public string MunicipalityCode { get; set; } = string.Empty;
        [Required]
        public string MunicipalityTitle { get; set; } = string.Empty;
        public Types MunicipalityType { get; set; }//enum
        [ForeignKey ("District")]
        public int DistrictId { get; set; }
        public bool Status { get; set; }
        [ JsonIgnore]
        public virtual District? District { get; set; }
       
    }

}
