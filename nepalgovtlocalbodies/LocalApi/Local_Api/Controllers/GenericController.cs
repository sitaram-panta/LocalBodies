using Local_Api.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Local_Api.Message;

namespace Local_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public abstract class GenericController<MainRepo,MainEntity, PKType> : ControllerBase
        where MainEntity : class
        where MainRepo :IGeneralRepo<MainEntity, PKType>
      
    {
        private readonly MainRepo _mainRepo;

        public GenericController(MainRepo mainRepo)
        {
            _mainRepo = mainRepo;
       
        }
        [HttpGet]
        public virtual async Task<ActionResult<List<MainEntity>>> GetList()
        {
            var items = await _mainRepo.GetList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<MainEntity>> Getbyid(PKType id)
        {
            var item = await _mainRepo.Getbyid(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public virtual async Task<ActionResult<MainEntity>> Create(MainEntity table)
        {
            var createdList = await _mainRepo.Create(table);
            return Ok(createdList);

        }

        [HttpPut]
        public virtual async Task<ActionResult<EditResult<MainEntity>>> Update(List<MainEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                return BadRequest("No entities provided for bulk update.");
            }

            var updatedEntities = await _mainRepo.BulkUpdate(entities);
            return Ok(updatedEntities);
        }

        [HttpDelete]
        public virtual async Task<ActionResult<DeleteResult<MainEntity>>> Delete(List<PKType> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest("No IDs provided for bulk delete.");
            }

            var deletedEntities = await _mainRepo.BulkDelete(ids);
            return Ok(deletedEntities);
        }
    }
}
