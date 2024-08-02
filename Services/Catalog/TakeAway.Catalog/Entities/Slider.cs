using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TakeAway.Catalog.Entities
{
	public class Slider
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SliderId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
