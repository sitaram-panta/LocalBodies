using Local_Api.Interface;
using Local_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Local_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : GenericController<IZoneRepo, Zone, int>
    {
        public ZoneController(IZoneRepo zone):base(zone)
        {
                
        }
    }
}
