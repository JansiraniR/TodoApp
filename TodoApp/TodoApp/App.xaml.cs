using System;
using TodoApp.LocalDB;
using TodoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp
{
    public partial class App : Application
    {
        public IDBWrapper DBWrapper;
        public App()
        {
            DBWrapper = new DBWrapper();

            DBWrapper.CreateTables();
            InitializeComponent();

            MainPage = new NavigationPage(new TodoItemsListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
