﻿using System;
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
                cm.AutoMap();
                cm.MapProperty(c => c.Name);
                cm.MapProperty(c => c.Cuisine);
                cm.MapProperty(c => c.Borough);
                cm.MapProperty(c => c.RestaurantId);
                cm.MapProperty(c => c.Grades);
            });

            BsonClassMap.RegisterClassMap<Grade>(cm =>
            {
                cm.AutoMap();
                cm.MapProperty(c => c.Date);
                cm.MapProperty(c => c.GradeValue);
                cm.MapProperty(c => c.Score);
            });

            BsonClassMap.RegisterClassMap<Address>(cm =>
            {
                cm.AutoMap();
                cm.MapProperty(c => c.Building);
                cm.MapProperty(c => c.Coord);
                cm.MapProperty(c => c.Street);
                cm.MapProperty(c => c.Zipcode);
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
        public DateTime Date { get; set; }
        public string GradeValue { get; set; }
        public int Score { get; set; }
    }

    public class Address
    {
        public string Building { get; set; }
        public string Coord { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
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
