using System;
using System.Collections.Generic;
using System.ComponentModel;
using TodoApp.Models;
using TodoApp.ViewModels;
using Xamarin.Forms;

namespace TodoApp.Views
{
    public partial class TodoItems : ContentPage, INotifyPropertyChanged
    {
        
        public TodoItems()
        {
            InitializeComponent();
            BindingContext = new TodItemsViewModel();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
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
