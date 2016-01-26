using MongoDB.Driver;

namespace MongoDataSource.DAL
{
    public class MongoRepository : IRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MongoRepository()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("restaurants");
        }
    }
}
