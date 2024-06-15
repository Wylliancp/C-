using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public abstract class BaseRepositoryADO<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly TasksContextADO _context;
        public BaseRepositoryADO(TasksContextADO context)
        {
            _context = context;
        }

        public bool Create(T item)
        {
            if (item == null)
                return false;

            var connection = _context.Connection();

            //connection.Open();


            string sql = "insert into tasks (id,dateUpdate) values (@id,@dateUpdate)";

            using(SqlCommand command = new SqlCommand(sql,connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = item.Id;

                command.Parameters.Add("@dateUpdate", SqlDbType.DateTime);
                command.Parameters["@dateUpdate"].Value = item.DateUpdate;

                var res = command.ExecuteNonQuery();
            }

            //connection.Close();
            return true;
        }

        public async Task<bool> CreateAsync(T item)
        {
            if (item == null)
                return false;

            var connection = _context.Connection();

            //await connection.OpenAsync();

            string sql = "insert into tasks (id,dateUpdate) values (@id,@dateUpdate)";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = item.Id;

                command.Parameters.Add("@dateUpdate", SqlDbType.DateTime);
                command.Parameters["@dateUpdate"].Value = item.DateUpdate;

                var res = await command.ExecuteNonQueryAsync();
            }

            //await connection.CloseAsync();
            return true;
        }

        public bool Update(int id, T item)
        {
            if (id == 0 && item == default)
                return false;

            var connection = _context.Connection();

            //connection.Open();

            string sql = "update Tasks set dateUpdate = @dateUpdate where id = @id";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                command.Parameters.Add("@dateUpdate", SqlDbType.DateTime);
                command.Parameters["@dateUpdate"].Value = item.DateUpdate;

                var res = command.ExecuteNonQuery();
            }

            //connection.Close();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, T item)
        {
            if (id == 0 && item == default)
                return false;

            var connection = _context.Connection();

            //await connection.OpenAsync();

            string sql = "update Tasks set dateUpdate = @dateUpdate where id = @id";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                command.Parameters.Add("@dateUpdate", SqlDbType.DateTime);
                command.Parameters["@dateUpdate"].Value = item.DateUpdate;

                var res = await command.ExecuteNonQueryAsync();
            }

            //await connection.CloseAsync();
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0)
                return false;

            var connection = _context.Connection();

            //connection.Open();

            string sql = "delete from tasks where id = @id";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                var res = command.ExecuteNonQuery();
            }

            //await connection.Close();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0 || id == default)
                return false;

            var connection = _context.Connection();

            //await connection.OpenAsync();

            string sql = "delete from tasks where id = @id";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                var res = await command.ExecuteNonQueryAsync();
            }

            //await await connection.CloseAsync();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            List<T> obj = default;

            var connection = _context.Connection();

            //connection.Open();

            string sql = "select * from tasks";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //obj = new { id = reader.GetInt32(0) };
                    }
                }
            }

            //connection.Close();

            return obj;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> obj = default;

            var connection = _context.Connection();

            //await connection.OpenAsync();

            string sql = "select * from tasks where id = @id";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        //obj = new[] { id = reader.GetInt32(0};
                    }
                }
            }

            //connection.Close();

            return obj;
        }

        public T GetById(int id)
        {
            T obj = default;

            var connection = _context.Connection();

            //connection.Open();

            string sql = "select * from tasks where id = @id";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //obj = new { id = reader.GetInt32(0) };
                    }
                }
            }

            //connection.Close();

            return obj;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T obj = default;

            var connection = _context.Connection();

            //await connection.OpenAsync();

            string sql = "select * from tasks where id = @id";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        //obj = new[] { id = reader.GetInt32(0) };
                    }
                }
            }

            //await connection.CloseAsync();

            return obj;
        }

        public bool Update(T item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}