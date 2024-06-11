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
    public class MunicipalityController : GenericController<IMunicipalityRepo, Municipality, int>
    {
        private readonly AppDbContext dbContext;

        public MunicipalityController(IMunicipalityRepo municipality, AppDbContext _dbContext) : base(municipality)
        {
            dbContext = _dbContext;
        }

        [HttpGet("bydistrict/{Districtid}")]
        public async Task<ActionResult<IEnumerable<Municipality>>> Id(int Districtid)
        {


            var Districts = await dbContext.Set<Municipality>()
                .Where(m => m.DistrictId == Districtid)
                .ToListAsync();

            return Ok(Districts);
        }


    }







}






