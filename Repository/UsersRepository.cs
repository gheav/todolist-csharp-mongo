using csharp_mongo.Core;
using csharp_mongo.Interfaces;
using csharp_mongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace csharp_mongo.Repository
{
    internal class UsersRepository : IUsersRepository
    {
        private IMongoCollection<Users> _usersCollection;

        public UsersRepository()
        {
            IMongoDatabase _database    = Connection.connMongoDB();
            _usersCollection            = _database.GetCollection<Users>("users");
        }

        public Users GetUser(string email)
        {
            var filter  = Builders<Users>.Filter.Eq("email", email);
            Users user  = _usersCollection.Find(filter).FirstOrDefault();
            return user;
        }

        public void InsertUser(Users user)
        {
            _usersCollection.InsertOne(user);
        }
    }
}
