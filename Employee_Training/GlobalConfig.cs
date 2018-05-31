using Employee_Training.DataAccess;
using System.Configuration;

namespace Employee_Training
{
    public class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnection()
        {
            SqlConnector sql = new SqlConnector();
            Connection = sql;
        }

        public static string ConnectDB(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
