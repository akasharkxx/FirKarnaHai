using System.Collections.Generic;
using System.Linq;

namespace FirKarnaHai
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel()
        {
            GroupedTodoList = GetGroupedTodoList();
        }
        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "Ye sab Karna Hai";
        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "phela kaam", IsCompleted = true},
            new TodoItem { Id = 1, Title = "dusra kaam"},
            new TodoItem { Id = 2, Title = "tisara kaam", IsCompleted = false},
        };

        private ILookup<string, TodoItem> GetGroupedTodoList()
        {
            return _todoList.OrderBy(t => t.IsCompleted)
                            .ToLookup(t => t.IsCompleted ? "Completed" : "Active");
        }
    }
}
