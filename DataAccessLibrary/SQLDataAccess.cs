using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SQLDataAccess(IConfiguration config)
        {
            this._config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                var data = await conn.QueryAsync<T>(sql, parameters);
                return data.ToList();

            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                await conn.ExecuteAsync(sql, parameters);

            }
        }
    }
}
