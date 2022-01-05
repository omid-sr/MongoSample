using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoSample.Controllers
{
    public class Parent : Document
    {
        public string Name { get; set; }

    }

}
