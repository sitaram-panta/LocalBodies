using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;

namespace Local_Api.Services
{
    public class ProvinceRepo:_AbsGeneralRepoServicecs<Province, int>, IProvinceRepo
    {
        public ProvinceRepo(AppDbContext context):base(context)
        {
            
        }
    }
}
