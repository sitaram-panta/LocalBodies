using Dapper;
using Local_Api.Interface;
using System.Data;

namespace Local_Api.Services
{
    public class DatabaseHelperService : IDatabaseHelper
    {
        private readonly IDbConnection _connection;

        public DatabaseHelperService(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<T> ExecuteQuery<T>(object parameters = null)
        {
            string storedProcedureName = "sp_getLogs";
            return _connection.Query<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure).AsList();
        }

    }
}
