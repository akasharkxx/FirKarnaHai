using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirKarnaHai
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListView : ContentPage
    {
        public TodoListView()
        {
            InitializeComponent();
            BindingContext = new TodoListViewModel();
        }
    }
}