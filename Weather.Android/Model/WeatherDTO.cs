namespace Weather.Android.Model
{
    public class WeatherDTO
    {
        public int Weather_Id { get; set; }
        public double Temperature { get; set; }
        public double Temperature_Feels { get; set; }
        public double Humidity { get; set; }
        public int Air_Quality_Num { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string Weather_Type { get; set; }
        public int Weather_Type_Id { get; set; }
        public int Wind_Speed { get; set; }
        public string WindDirection { get; set; }
        public string WindLeveL { get; set; }

        public string AirQuailty { get; set; }
        public string ExtraInfo { get; set; }
    }
}