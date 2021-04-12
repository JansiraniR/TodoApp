using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using TodoApp.LocalDB;
using TodoApp.Models;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class TodoItemListViewModel : INotifyPropertyChanged
    {

        public IDBWrapper DBWrapper { get { return new DBWrapper(); } }
        private List<TodoItem> _todolist;
        public List<TodoItem> TodoList
        {
            get { return _todolist; }
            set
            {
                _todolist = value;
                OnPropertyChanged(nameof(TodoList));
            }
        }

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

        public ICommand SaveCommand { get; }

        public TodoItemListViewModel()
        {
            SaveCommand = new Command(async () =>
                {
                    try
                    {
                    //Todo: get from api
                    var items = await DBWrapper.GetTodoItemsAsync();
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
