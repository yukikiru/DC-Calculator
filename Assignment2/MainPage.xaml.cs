using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment2.Model;

namespace Assignment2
{
    public partial class MainPage : ContentPage
    {
        Manager m;
        NetworkingManager networkManager = new NetworkingManager();
        public MainPage(ref Manager man)
        {
            InitializeComponent();
            m = man;
        }

        protected async override void OnAppearing()
        {
            var weather = await networkManager.GetWeather();
            current.Text = "Current Temperature: " + ((int)(weather.main.temp-273.15)).ToString() + "C";
            feelsLike.Text = "Feels Like: " + ((int)(weather.main.feels_like - 273.15)).ToString() + "C";
            weatherLabel.Text = "Weather for " + weather.name;
            conditions.Text = weather.weather[0].description;
            dailyMin.Text = ((int)(weather.main.temp_min - 273.15)).ToString() + "C";
            dailyMax.Text = ((int)(weather.main.temp_max - 273.15)).ToString() + "C";
            humidity.Text = $"Humidity: {weather.main.humidity}%";
        }

        async public void navToCalculator(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalculatorNav(ref m));
        }

        async void navToHourTracker(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HoursNav(ref m));
        }
    }
}
