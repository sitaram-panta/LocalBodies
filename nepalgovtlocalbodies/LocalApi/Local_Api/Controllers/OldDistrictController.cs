using Local_Api.Data;
using Local_Api.Interface;
using Local_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Local_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldDistrictController : GenericController<IOldDistrictRepo, OldDistrict, int>
    {
        private readonly AppDbContext dbContext;

        public OldDistrictController(IOldDistrictRepo OldDistrict, AppDbContext _dbContext) : base(OldDistrict)
        {
            dbContext = _dbContext;
        }



        [HttpGet("ByZone")]
        public async Task<ActionResult<IEnumerable<OldDistrict>>> GetbyZone(int Zoneid)
        { 
            var oldDistricts = await dbContext.Set<OldDistrict>().Where(m => m.ZoneId == Zoneid).ToListAsync();
            return Ok (oldDistricts);

        
        
        }
            

    }
}

