using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intertek.Data.Helpers
{
    public interface IDbHelper
    {
        Task<DataTable> ExecuteQueryAsync(string query, SqlParameter[] parameters = null);
        Task<int> ExecuteNonQueryAsync(string commandText, SqlParameter[] parameters = null);
        Task<object> ExecuteScalarAsync(string commandText, SqlParameter[] parameters = null);
        SqlParameter CreateParameter(string name, object value, SqlDbType dbType);
    }
}
