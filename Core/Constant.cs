using System.Configuration;

namespace csharp_mongo.Core
{
    public class Constant
    {
        public static string Database           => ConfigurationManager.AppSettings["Database"].ToString();
        public static string ConnectionString   => ConfigurationManager.AppSettings["ConnectionString"].ToString();
    }
}
