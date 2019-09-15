using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirKarnaHai.Persistence
{
    public class TodoRepository
    {
        private readonly SQLiteAsyncConnection _database;
        public TodoRepository()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("TODOSQLite.db3"));
            _database.CreateTableAsync<TodoItem>().Wait();
        }

        private List<TodoItem> _seedTodoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "phela kaam", IsCompleted = true},
            new TodoItem { Id = 1, Title = "dusra kaam"},
            new TodoItem { Id = 2, Title = "tisara kaam", IsCompleted = false},
        };

        public async Task<List<TodoItem>> GetList()
        {
            if (await _database.Table<TodoItem>().CountAsync() == 0)
            {
                await _database.InsertAllAsync(_seedTodoList);
            }

            return await _database.Table<TodoItem>().ToListAsync();
        }

        public Task DeleteItems(TodoItem itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete);
        }

        public Task ChangeIsCompleted(TodoItem itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
            return _database.UpdateAsync(itemToChange);
        }

        public Task AddItems(TodoItem itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }
    }
}
