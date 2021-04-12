using System;
using System.ComponentModel;
using System.Windows.Input;
using TodoApp.LocalDB;
using TodoApp.Models;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class ViewTodoItemsViewModel: INotifyPropertyChanged
    {

        public IDBWrapper DBWrapper { get { return new DBWrapper(); } }
        private TodoItem _todoItem;
        public TodoItem TodoItem
        {
            get { return _todoItem; }
            set
            {
                _todoItem = value;
                OnPropertyChanged(nameof(TodoItem));
            }
        }

        public ICommand EditCommand { get; }

        public ViewTodoItemsViewModel()
        {
            EditCommand = new Command(async () =>
            {
                try
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception ex)
                {

                }
            });

            TodoItem = new TodoItem { Notes = "Test", Task = "Tasksbd" };
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
