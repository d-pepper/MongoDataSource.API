using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDataSource.DAL
{
    public class MongoRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<BsonDocument> _collection; 

        public MongoRepository()
        {
            var connectionstring = "mongodb://localhost:27017";

            _client = new MongoClient(connectionstring);
            _database = _client.GetDatabase("restaurants");
            _collection = _database.GetCollection<BsonDocument>("restaurants");
        }

        public async Task<IAsyncCursor<BsonDocument>> GetAll()
        {
            return await _collection.FindAsync(new BsonDocument());
        }
    }
}
