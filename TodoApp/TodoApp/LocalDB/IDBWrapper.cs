using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.LocalDB
{
    public interface IDBWrapper
    {
        void CreateTables();
        Task<bool> IsDBExistAsync();
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task<bool> DeleteItemsAsync(TodoItem todoItem);
        Task<bool> InsertItemsAsync(TodoItem todoItem);
        Task ClearDB();
    }
}
