using Local_Api.Data;
using Local_Api.Interface;
using Microsoft.EntityFrameworkCore;
using static Local_Api.Message;

namespace Local_Api.Services
{
    public abstract class _AbsGeneralRepoServicecs<MainEntity, PKType> : IGeneralRepo<MainEntity, PKType>
        where MainEntity : class
    {
        private readonly AppDbContext dbContext;

        public _AbsGeneralRepoServicecs(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<MainEntity>> GetList()
        {
            return await dbContext.Set<MainEntity>().ToListAsync();
        }

        public async Task<MainEntity> Getbyid(PKType id)
        {
            return await dbContext.Set<MainEntity>().FindAsync(id);

        }

        public async Task<MainEntity> Create(MainEntity table)
        {
            dbContext.Set<MainEntity>().Add(table);
            await dbContext.SaveChangesAsync();
            return table;
        }

        public async Task<EditResult<List<MainEntity>>> BulkUpdate(List<MainEntity> entities)
        {
            foreach (var entity in entities)
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }

            await dbContext.SaveChangesAsync();

            return new EditResult<List<MainEntity>>
            {
                IsSuccess = true,
                Message = "Bulk edit successful",
                EditedEntity = entities
            };
        }
        public async Task<DeleteResult<List<MainEntity>>> BulkDelete(List<PKType> ids)
        {
            var deletedEntities = new List<MainEntity>();

            foreach (var id in ids)
            {
                var entityToDelete = await dbContext.Set<MainEntity>().FindAsync(id);

                if (entityToDelete != null)
                {
                    dbContext.Set<MainEntity>().Remove(entityToDelete);
                    deletedEntities.Add(entityToDelete);
                }
            }

            await dbContext.SaveChangesAsync();

            return new DeleteResult<List<MainEntity>>
            {
                IsSuccess = true,
                Message = "Bulk delete successful",
                DeletedEntity = deletedEntities
            };
        }



    }


}








