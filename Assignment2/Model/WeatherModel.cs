using System;
using System.Collections.Generic;

namespace Assignment2.Model
{
    //Model for openWeather data
    public class WeatherModel
    {
        public Coord coord;
        public List<Weather> weather;
        public string b;
        public TempData main;
        public int visibility;
        public Wind wind;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int timeZone;
        public int ID;
        public string name;
        public int cod;

        public WeatherModel()
        {
        }
    }

    public class Coord{
        public string lon;
        public string lat;
    }
    public class TempData
    {
        public double temp; //in kelvin
        public double feels_like; //in kelvin
        public double temp_min;
        public double temp_max;
        public int pressure;
        public int humidity;
    }
    public class Weather
    {
        public int ID;
        public string weather;
        public string description;
        public string icon;
    }
    public class Wind
    {
        public double speed;
        public double degree;
        public double gust;
    }
    public class Clouds
    {
        public int all;
    }
    public class Sys
    {
        public int type;
        public int ID;
        public string country;
        public int sunrise;
        public int sunset;
    }
}
