namespace Local_Api.Interface
{
    public interface IDatabaseHelper
    {
        List<T> ExecuteQuery<T>(object parameters = null);
    }
}
