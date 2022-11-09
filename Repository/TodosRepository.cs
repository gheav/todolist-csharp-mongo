using csharp_mongo.Core;
using csharp_mongo.Interfaces;
using csharp_mongo.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace csharp_mongo.Repository
{
    internal class TodosRepository : ITodosRepository
    {
        private IMongoCollection<Todos> _todoCollection;
        public TodosRepository()
        {
            IMongoDatabase _database = Connection.connMongoDB();
            _todoCollection = _database.GetCollection<Todos>("todo");
        }
        public void InsertTodo(Todos todo)
        {
            _todoCollection.InsertOne(todo);
        }

        public IEnumerable<Todos> GetTodos(string email)
        {
            var filter  = Builders<Todos>.Filter.Eq("email", email);
            var todo = _todoCollection.Find(filter).ToList();
            return todo;
        }

        public void UpdateTodo(Todos todo)
        {
          //  throw new System.NotImplementedException();
        }

        public void DeleteTodo(Todos todo)
        {
          //  throw new System.NotImplementedException();
        }

    }
}
