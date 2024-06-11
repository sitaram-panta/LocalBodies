using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;

namespace Local_Api.Services
{
    public class ZoneRepo:_AbsGeneralRepoServicecs<Zone, int>, IZoneRepo
    {
        public ZoneRepo(AppDbContext context):base(context)
        {
            
        }
    }
}
