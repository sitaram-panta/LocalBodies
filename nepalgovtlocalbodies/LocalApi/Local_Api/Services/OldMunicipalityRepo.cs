using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;

namespace Local_Api.Services
{
    public class OldMunicipalityRepo:_AbsGeneralRepoServicecs<OldMunicipality, int>, IOldMunicipalityRepo
    {
        public OldMunicipalityRepo(AppDbContext context): base(context) 
        {
            
        }
    }
}
