using Todo.DTO;
using Todo.ViewModel;
using Xamarin.Forms;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TodoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btnBuscar.Command.Execute(null);
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await (BindingContext as TodoViewModel)
                        .AddTodo(new DTO.Todo { Nome = newItemName.Text });

            btnBuscar.Command.Execute(null);

            newItemName.Text = string.Empty;
            newItemName.Unfocus();
        }
    }
}
