using System.Threading.Tasks;
using System.Web.Http;
using MongoDataSource.DAL;
using MongoDB.Bson.Serialization;

namespace MongoDataSource.API.Controllers
{
    public class RestaurantsController : ApiController
    {
        public async Task<IHttpActionResult> GetAll()
        {
            var repository = new MongoRepository();

            var collection = await repository.GetAll();

            BsonClassMap.RegisterClassMap<Restaurant>(cm =>
            {
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.Cuisine);
            });
            

            return Ok(collection);
        }
    }

    public class Restaurant
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
    }
}
