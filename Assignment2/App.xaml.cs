using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment2.Model;

namespace Assignment2
{
    public partial class App : Application
    {

        //Set up global manager that is shared by all pages
        Manager m;
        public App()
        {
            InitializeComponent();
            m = new Manager();
            MainPage = new NavigationPage(new MainPage(ref m));
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
