using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tearc.Repository.Mongo
{
    public class MongoDatabaseFactory
    {
        public static IMongoDatabase Create(string connectionName = "Mongo")
        {
            var url = new MongoUrl("TearcConnection");
            var client = new MongoClient(url);
            var db = client.GetDatabase(url.DatabaseName);

            return db;
        }
    }
}
