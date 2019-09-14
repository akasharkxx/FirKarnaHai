using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirKarnaHai.Persistence
{
    public class TodoRepository
    {
        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "phela kaam", IsCompleted = true},
            new TodoItem { Id = 1, Title = "dusra kaam"},
            new TodoItem { Id = 2, Title = "tisara kaam", IsCompleted = false},
        };

        public Task<List<TodoItem>> GetList()
        {
            return Task.FromResult(_todoList);
        }

        public Task<List<TodoItem>> DeleteItems(TodoItem itemToDelete)
        {
            _todoList.Remove(itemToDelete);
            return Task.Delay(100);
        }

        public Task<List<TodoItem>> ChangeIsCompleted(TodoItem itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
            return Task.Delay(1000);
        }

        public Task<List<TodoItem>> AddItems(TodoItem itemToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
