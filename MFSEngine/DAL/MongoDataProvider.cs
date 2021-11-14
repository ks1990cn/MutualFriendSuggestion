using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class MongoDataProvider
    {
        private IMongoDatabase database;
        public MongoDataProvider(string database)
        {
            var client = new MongoClient();
            this.database = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string Table, T record)
        {
            var collection = this.database.GetCollection<T>(Table);
            collection.InsertOne(record);
        }

    }
}
