namespace Local_Api
{
    public class Message
    {
        public class DeleteResult<T>
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public T DeletedEntity { get; set; }
        }

        public class EditResult<T>
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public T EditedEntity { get; set; }
        }

        public DeleteResult<List<T>> BulkDelete<T>(List<T> entities)
        {
            // Perform bulk deletion logic here.

            var result = new DeleteResult<List<T>>
            {
                IsSuccess = true,
                Message = "Bulk delete successful",
                DeletedEntity = entities
            };

            return result;
        }

        public EditResult<List<T>> BulkEdit<T>(List<T> entities)
        {
            // Perform bulk editing logic here.

            var result = new EditResult<List<T>>
            {
                IsSuccess = true,
                Message = "Bulk edit successful",
                EditedEntity = entities
            };

            return result;
        }
    }
}
