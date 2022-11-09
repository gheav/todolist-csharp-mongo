using csharp_mongo.Models;
using System.Collections.Generic;

namespace csharp_mongo.Interfaces
{
    internal interface ITodosRepository
    {
        IEnumerable<Todos> GetTodos(string email);
        void InsertTodo(Todos todo);
        void UpdateTodo(Todos todo);
        void DeleteTodo(Todos todo);
        
    }
}
