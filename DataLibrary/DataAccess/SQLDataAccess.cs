using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLibrary.DataAccess
{
    public static class SQLDataAccess
    {
        public static string GetConnectionString(string connectionName = "Ad-Link-ProDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static List<AnyModel> LoadData<AnyModel>(string sql)
        {
            using (IDbConnection cn = new SqlConnection(GetConnectionString()))
            {
                return cn.Query<AnyModel>(sql).ToList();
            }
            
        }
        public static int ExecuteQuery<AnyModel>(string sql,AnyModel model)
        {
            using (IDbConnection cn = new SqlConnection(GetConnectionString()))
            {
                return cn.Execute(sql, model);                
            }
        }
        
    }
}
