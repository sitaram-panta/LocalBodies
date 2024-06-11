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
    public class OldMunicipalityController : GenericController<IOldMunicipalityRepo, OldMunicipality, int>
    {
        private readonly AppDbContext dbContext;

        public OldMunicipalityController(IOldMunicipalityRepo old_Municipality, AppDbContext _dbContext):base(old_Municipality)
        {
            dbContext = _dbContext;
        }
        [HttpGet("byolddistrictid")]
        public async Task<ActionResult<IEnumerable<OldMunicipality>>> GetbyOldDistrict(int oldDistrictId)
        { 
            var oldmunicipalities =  await dbContext.Set<OldMunicipality>().Where(m => m.OldDistrictId == oldDistrictId).ToListAsync();
            return Ok(oldmunicipalities);
        
        }
    }
}
