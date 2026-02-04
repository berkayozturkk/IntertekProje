using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertek.Data.Helpers
{
    public class DbHelper : IDbHelper
    {
        private readonly IConfiguration _configuration;

        public DbHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("Not found ConnectionString.");
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public SqlParameter CreateParameter(string name, object value, SqlDbType dbType)
        {
            return new SqlParameter(name, dbType) { Value = value ?? DBNull.Value };
        }

        public async Task<int> ExecuteNonQueryAsync(string commandText, SqlParameter[] parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<object> ExecuteScalarAsync(string commandText, SqlParameter[] parameters = null)
        {
            throw new NotImplementedException();
        }

        public async Task<DataTable> ExecuteQueryAsync(string query, SqlParameter[] parameters = null)
        {
            using (var connection = CreateConnection())
            using (var command = new SqlCommand(query, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                var dataTable = new DataTable();
                await Task.Run(() => adapter.Fill(dataTable));
                return dataTable;
            }
        }
    }
}
