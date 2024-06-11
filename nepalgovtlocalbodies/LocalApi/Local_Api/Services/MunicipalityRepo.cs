using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;

namespace Local_Api.Services
{
    public class MunicipalityRepo:_AbsGeneralRepoServicecs<Municipality, int>, IMunicipalityRepo
    {
        public MunicipalityRepo(AppDbContext context):base(context) 
        {
                
        }
    }
}
