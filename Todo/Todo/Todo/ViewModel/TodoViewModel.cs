using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.API;
using Todo.DTO;
using Todo.Extension;
using Xamarin.Forms;

namespace Todo.ViewModel
{
    public class TodoViewModel : ViewModelBase
    {
        private ObservableCollection<DTO.Todo> _todos;
        private readonly ICommand _loadTodoCommand;
        //private readonly ICommand _addTodoCommand;
        public ObservableCollection<DTO.Todo> Todos
        {
            get => _todos;
            set
            {
                _todos = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadTodoCommand => _loadTodoCommand;

        public TodoViewModel()
            :base("Todo List")
        {
            Todos = new ObservableCollection<DTO.Todo>();
            //Todos.Add(new DTO.Todo { Nome = "Teste Hard" });
            _loadTodoCommand = new Command(LoadItens);
        }

        private async void LoadItens()
        {
            if (Loading)
                return;
            Loading = true;
            try
            {
                Todos = new ObservableCollection<DTO.Todo>(await TodoAPI.Instance.GetaTodoListAsync());
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                Loading = false;
            }
        }

        public async Task AddTodo(object item)
        {
            try
            { 
                await TodoAPI.Instance.Add(item as DTO.Todo);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}

