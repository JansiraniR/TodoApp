using System;
using System.Collections.Generic;
using TodoApp.ViewModels;
using Xamarin.Forms;

namespace TodoApp.Views
{
    public partial class ViewTodoItem : ContentPage
    {
        public ViewTodoItem()
        {
            InitializeComponent();
            BindingContext = new ViewTodoItemsViewModel();
        }
    }
}
