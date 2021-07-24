using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dark.Views;
using Dark.Views.welcome;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Dark
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new Welcome());
          
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
