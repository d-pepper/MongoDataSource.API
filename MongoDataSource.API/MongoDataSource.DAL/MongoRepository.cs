using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDataSource.DAL
{
    public class MongoRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MongoRepository()
        {
            var connectionstring = "mongodb://localhost:27017";

            _client = new MongoClient(connectionstring);
            _database = _client.GetDatabase("restaurants");
            var col = _database.GetCollection<BsonDocument>("restaurants");

        }
    }


}
