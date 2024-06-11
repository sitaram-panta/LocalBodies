using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;

namespace Local_Api.Services
{
    public class OldDistrictService:_AbsGeneralRepoServicecs<OldDistrict, int>, IOldDistrictRepo
    {
        public OldDistrictService(AppDbContext context):base(context) 
        {
                
        }
    }
}
