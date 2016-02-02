using System.Collections.Generic;
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
        public Address Address { get; set; }
        public string Borough { get; set; }
        public List<Grade> Grades { get; set; }
        public int RestaurantId { get; set; }
        
    }

    public class Grade
    {
    }

    public class Address
    {
    }

//    {
//	"_id": ObjectId("56b0bed833966a3c5898a75b"),
//	"address": {
//		"building": "705",
//		"coord": [-73.9653967, 40.6064339],
//		"street": "Kings Highway",
//		"zipcode": "11223"
//	},
//	"borough": "Brooklyn",
//	"cuisine": "Jewish/Kosher",
//	"grades": [{
//		"date": ISODate("2014-11-10T00:00:00Z"),
//		"grade": "A",
//		"score": 11
//	}, {
//		"date": ISODate("2013-10-10T00:00:00Z"),
//		"grade": "A",
//		"score": 13
//	}, {
//		"grade": "A",
//		"score": 7,
//		"date": ISODate("2012-10-04T00:00:00Z")
//	}, {
//		"score": 9,
//		"date": ISODate("2012-05-21T00:00:00Z"),
//		"grade": "A"
//	}, {
//		"date": ISODate("2011-12-30T00:00:00Z"),
//		"grade": "B",
//		"score": 19
//	}],
//	"name": "Seuda Foods",
//	"restaurant_id": "40360045"
//}

}
