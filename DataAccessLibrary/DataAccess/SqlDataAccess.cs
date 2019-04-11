using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal("HireDanteJonesDB")))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int ExecuteDate<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal("HireDanteJonesDB")))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
