using static Local_Api.Message;

namespace Local_Api.Interface
{
    public interface IGeneralRepo<MainEntity, PKType> where MainEntity : class
    {

        public Task<List<MainEntity>> GetList();

        public Task<MainEntity> Getbyid(PKType id);

       public Task<MainEntity> Create(MainEntity table);

       public Task<EditResult<List<MainEntity>>> BulkUpdate(List<MainEntity> entities);
        public Task<DeleteResult<List<MainEntity>>> BulkDelete(List<PKType> ids);
    }

}
