using MongoDB.Bson;
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
        public List<T> LoadRecords<T>(string Table,int limit)
        {
            var collection = this.database.GetCollection<T>(Table);
            return collection.Find(new BsonDocument()).Limit(limit).ToList();
        } 
        public T LoadRecordsById<T>(string Table,int Id)
        {
            var collection = this.database.GetCollection<T>(Table);
            var filter = Builders<T>.Filter.Eq("Id", Id);
            return collection.Find(filter).First();
        }
    }
}
