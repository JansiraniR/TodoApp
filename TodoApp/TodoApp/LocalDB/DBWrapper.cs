using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.LocalDB
{
    public class DBWrapper : IDBWrapper
    {

        public ISQLiteStorage<TodoItem> TodoItemsDB { get; set; }

        public DBWrapper()
        {

        }

        public async Task ClearDB()
        {
            try
            {
                if (null == TodoItemsDB)
                { return; }

                await TodoItemsDB.Clear();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);

            }
        }

        public void CreateTables()
        {
            TodoItemsDB = new SQLiteStorage<TodoItem>("");

        }

        public async Task<bool> IsDBExistAsync()
        {
            if (null == TodoItemsDB) return false;

            return true;

        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            try
            {
                var todoItems = await TodoItemsDB.Get();

                return todoItems;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception : " + ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteItemsAsync(TodoItem todoItem)
        {

            if (null == TodoItemsDB) return false;

            var todoItems = await TodoItemsDB.Get();
            foreach (var item in todoItems)
            {
                if (item.Task == todoItem.Task)
                {
                    return await TodoItemsDB.Delete(todoItem) > 0;
                }
            }

            return false;

        }


        public async Task<bool> InsertItemsAsync(TodoItem todoItem)
        {
            if (null == TodoItemsDB) throw new Exception("DB not Found");

            await TodoItemsDB.Insert(todoItem);

            return true;
        }

    }
}