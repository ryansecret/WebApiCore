using System.Collections.Generic;
using System.Reflection;
using DapperEx;
using DapperEx.Mapper;
using DapperEx.Sql;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NDaisy.Core.ServiceLocator;
 
namespace WebApiCore.Repository
{
    public static class DbTool
    {  
        

        private static readonly ISqlGenerator _sqlGenerator;

        public static IDatabase GetDb()
        {
            
            IConfigurationRoot config= ServiceLocator.Current.GetInstance<IConfigurationRoot>();
            var connection = new MySqlConnection(config.GetConnectionString("database"));
            return new Database(connection, _sqlGenerator);
        }

        static DbTool()
        {
          
            var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>() { typeof(DbTool).GetTypeInfo().Assembly }, new MySqlDialect());
             
            _sqlGenerator = new SqlGeneratorImpl(config);
        }
    }

   
}