using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace FirKarnaHai
{
    class AddTodoItemViewModel : BaseFodyObservable
    {
        public AddTodoItemViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
        }

        private INavigation _navigation;
        public string TodoTitle { get; set; }

        public Command Save { get; set; }

        public Command Cancel { get; set; }

        public async void HandleSave()
        {
            await App.TodoRepository.AddItems(new TodoItem { Title = TodoTitle });
            await _navigation.PopModalAsync();
        }

        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}
