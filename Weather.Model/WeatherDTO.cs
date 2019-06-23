using System;

namespace Weather.Model
{
    public class WeatherDTO
    {
        public int Weather_Id { get; set; }
        public Nullable<double> Temperature { get; set; }
        public double Temperature_Feels { get; set; }
        public Nullable<double> Humidity { get; set; }
        public Nullable<int> Air_Quality_Num { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public int Weather_Type_Id { get; set; }
        public string Weather_Type { get; set; }
        public int Wind_Speed { get; set; }
        public string WindDirection { get; set; }
        public string WindLeveL { get; set; }

        public string AirQuailty { get; set; }
        public string ExtraInfo { get; set; }

        public WeatherDTO(Weather weather,
       Wind_Levels windLevel,
        Air_Quality_Types airQuality,
       Location_Aware_Message msg

        )
        {
            this.Weather_Id = weather.Weather_Id;
            this.Temperature = weather.Temperature;
            this.Temperature_Feels = weather.Temperature_Feels;
            this.Humidity = weather.Humidity;
            this.Air_Quality_Num = weather.Air_Quality_Num;
            this.Country = weather.Spatial == null ? String.Empty : weather.Spatial.Country;
            this.City = weather.Spatial == null ? String.Empty : weather.Spatial.City;
            this.WindLeveL = windLevel.Level;
            this.Wind_Speed = weather.Wind_Speed.HasValue ? weather.Wind_Speed.Value : 0;
            this.AirQuailty = airQuality == null ? String.Empty : airQuality.Description;
            this.Weather_Type = weather.Weather_Types == null ? String.Empty : weather.Weather_Types.Weather_Type;
            this.Weather_Type_Id = weather.Weather_Types == null ? 0 : weather.Weather_Types.Weather_Type_Id;
            this.WindDirection = weather.Wind_Directions == null ? String.Empty : weather.Wind_Directions.Description;
            this.WindLeveL = windLevel == null ? String.Empty : windLevel.Level;
            this.ExtraInfo = msg == null ? String.Empty : msg.Message;
        }
    }
}