using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FirKarnaHai
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel(INavigation navigation)
        {
            _navigation = navigation;

            GetGroupedTodoList().ContinueWith(t =>
            {
                GroupedTodoList = t.Result;
            });
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
            AddItem = new Command(HandleAddItem);
        }

        private INavigation _navigation;
        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "Ye sab Karna Hai";
        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "phela kaam", IsCompleted = true},
            new TodoItem { Id = 1, Title = "dusra kaam"},
            new TodoItem { Id = 2, Title = "tisara kaam", IsCompleted = false},
        };

        public Command AddItem { get; set; }
        public Command<TodoItem> Delete { get; set; }
        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public async void HandleDelete(TodoItem itemToDelete)
        {
            await App.TodoRepository.DeleteItems(itemToDelete);
            GroupedTodoList = await GetGroupedTodoList();
        }

        public async void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            await App.TodoRepository.ChangeIsCompleted(itemToUpdate);
            GroupedTodoList = await GetGroupedTodoList();
        }

        public async void HandleAddItem()
        {
            await _navigation.PushModalAsync(new AddTodoItem());
        }

        private async Task<ILookup<string, TodoItem>> GetGroupedTodoList()
        {
            return (await App.TodoRepository.GetList())
                            .OrderBy(t => t.IsCompleted)
                            .ToLookup(t => t.IsCompleted ? "Hogaya" : "Chal Raha hai");
        }

        public async Task RefreshTaskList()
        {
            GroupedTodoList = await GetGroupedTodoList();
        }
    }
}
