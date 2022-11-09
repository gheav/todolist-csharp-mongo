using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_mongo.Core
{
    internal class Connection
    {
        public static IMongoDatabase connMongoDB()
        {
            MongoClient mongoClient         = new MongoClient(Constant.ConnectionString);
            IMongoDatabase mongoDatabase    = mongoClient.GetDatabase(Constant.Database);
            return mongoDatabase;
        }
    }
}
