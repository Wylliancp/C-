using System.Data.SqlClient;

namespace Infra.Context
{
    public class TasksContextADO 
    {

        private SqlConnection _conn;
        public TasksContextADO(string connectionString)
        {
            _conn = new SqlConnection(connectionString);
        }

        public SqlConnection Connection() => _conn;
    }
}
