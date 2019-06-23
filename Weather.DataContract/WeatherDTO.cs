using System;
using System.Runtime.Serialization;


namespace Weather.DataContract
{
    [DataContract]
    [Serializable]
    public class WeatherDTO
    {
        public Weather weather { get; set; }

    }
}
