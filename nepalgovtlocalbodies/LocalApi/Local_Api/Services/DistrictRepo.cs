using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;

namespace Local_Api.Services
{
    public class DistrictRepo:_AbsGeneralRepoServicecs<District, int>, IDistrictRepo
    {
        private readonly AppDbContext context;

        public DistrictRepo(AppDbContext _context):base(_context) 
        {
            context = _context;
        }
    }
}
