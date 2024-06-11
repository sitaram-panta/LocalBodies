using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Local_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : GenericController<IDistrictRepo, District, int>
    {
        private readonly AppDbContext dbContext;

        public DistrictController(IDistrictRepo district, AppDbContext _dbContext):base(district)
        {
            dbContext = _dbContext;
        }



        [HttpGet("byprovince")]
        public async Task<ActionResult<IEnumerable<District>>> GetDistrictbyprovinceid(int provinceId)
        {


            var modules = await dbContext.Set<District>()
                .Where(m => m.ProvinceId == provinceId)
                .ToListAsync();

            return Ok(modules);
        }
    }
}
