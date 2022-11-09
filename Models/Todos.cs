using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace csharp_mongo.Models
{
    public class Todos
    {
        public ObjectId _id { get; set; }
        public string email { get; set; }
        public string[] actions { get; set; }
    }

}
