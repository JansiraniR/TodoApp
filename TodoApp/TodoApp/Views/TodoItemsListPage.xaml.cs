using System;
using System.Collections.Generic;
using TodoApp.LocalDB;
using TodoApp.Models;
using TodoApp.ViewModels;
using Xamarin.Forms;

namespace TodoApp.Views
{
    public partial class TodoItemsListPage : ContentPage
    {
        public IDBWrapper DBWrapper { get { return new DBWrapper(); } }
        public TodoItemsListPage()
        {
            InitializeComponent();
            BindingContext = new TodoItemListViewModel();
            GetTodoTasks();
        }
        async void GetTodoTasks()
        {
            ////Todo:  get from API
            //var items = await DBWrapper.GetTodoItemsAsync();
            //if (items != null)
            //{
            //    listView.ItemsSource = items;
            //}


        }

        async void listView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItems
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }


        async void OnItemAdded(object sender, EventArgs e)
        {
            try
            {
                await App.Current.MainPage.Navigation.PushAsync(new TodoItems());
            }
            catch(Exception ex)
            {

            }
        }

    }
}
