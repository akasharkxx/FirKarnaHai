using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FirKarnaHai
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel()
        {
            GroupedTodoList = GetGroupedTodoList();
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
        }
        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "Ye sab Karna Hai";
        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "phela kaam", IsCompleted = true},
            new TodoItem { Id = 1, Title = "dusra kaam"},
            new TodoItem { Id = 2, Title = "tisara kaam", IsCompleted = false},
        };

        public Command<TodoItem> Delete { get; set; }
        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public void HandleDelete(TodoItem itemToDelete)
        {
            _todoList.Remove(itemToDelete);
            GroupedTodoList = GetGroupedTodoList();
        }

        public void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            itemToUpdate.IsCompleted = !itemToUpdate.IsCompleted;
            GroupedTodoList = GetGroupedTodoList();
        }

        private ILookup<string, TodoItem> GetGroupedTodoList()
        {
            return _todoList.OrderBy(t => t.IsCompleted)
                            .ToLookup(t => t.IsCompleted ? "Completed" : "Active");
        }
    }
}
