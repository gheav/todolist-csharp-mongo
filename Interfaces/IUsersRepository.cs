using csharp_mongo.Models;

namespace csharp_mongo.Interfaces
{
    internal interface IUsersRepository
    {
        Users GetUser(string email);

        void InsertUser(Users user);
    }
}
