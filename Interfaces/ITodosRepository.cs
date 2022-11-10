using csharp_mongo.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace csharp_mongo.Interfaces
{
    internal interface ITodosRepository
    {
        IEnumerable<Todos> GetActions(string email);
        void InsertTodo(Todos todo);
        void UpdateTodo(Todos todo);
        void DeleteTodo(Todos todo);
        
    }
}
