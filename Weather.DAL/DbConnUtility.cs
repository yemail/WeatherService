using System;
using System.Configuration;
using System.Data.EntityClient;

namespace Weather.DAL
{
    internal class DbConnUtility
    {
        private static readonly string DB_SERVER = ConfigurationManager.AppSettings["DB_SERVER"];
        private static readonly string DB_DATABASE = ConfigurationManager.AppSettings["DB_DATABASE"];
        private static readonly string DB_PASSWORD = ConfigurationManager.AppSettings["DB_PASSWORD"];
        private static readonly string DB_USERNAME = ConfigurationManager.AppSettings["DB_USERNAME"];

        public static string BuildEFConnectionString(Type typeofEntities, string edmxFileName)
        {
            string connectionString = @"metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string='data source={1};initial catalog={2};Trusted_Connection=true;'";
            connectionString = string.Format(connectionString, edmxFileName, DB_SERVER, DB_DATABASE);

            if (!string.IsNullOrEmpty(DB_PASSWORD) && !string.IsNullOrEmpty(DB_USERNAME))
            {
                connectionString = @"metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl;provider=System.Data.SqlClient;provider connection string='data source={1};initial catalog={2};user id={3};password={4};persist security info=True;'";
                connectionString = string.Format(connectionString, edmxFileName, DB_SERVER, DB_DATABASE, DB_USERNAME, DB_PASSWORD);
            }

            var csBuilder = new EntityConnectionStringBuilder(connectionString);
            csBuilder.Metadata = csBuilder.Metadata.Replace("res://*/", string.Format("res://{0}/", typeofEntities.Assembly.FullName));
            return csBuilder.ToString();
        }

        public static string BuildADOConnectionString()
        {
            string connectionString = @"data source={0};initial catalog={1};persist security info=True;Trusted_Connection=true;";
            connectionString = string.Format(connectionString, DB_SERVER, DB_DATABASE);
            return connectionString;
        }
    }
}