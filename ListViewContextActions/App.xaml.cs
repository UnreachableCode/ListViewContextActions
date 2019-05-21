using System;
using FreshMvvm;
using ListViewContextActions.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewContextActions
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = FreshPageModelResolver.ResolvePageModel<PeopleListPageModel>();
            MainPage = new FreshNavigationContainer(mainPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
