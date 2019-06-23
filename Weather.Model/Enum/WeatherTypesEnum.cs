using System.Runtime.Serialization;

namespace Weather.Model.Enum
{
    [DataContract(Name = "WeatherTypesEnum")]
    public enum WeatherTypesEnum
    {
        [EnumMember(Value = "Sunny")]
        Sunny = 10,

        [EnumMember(Value = "Rainy")]
        Rainy = 20,

        [EnumMember(Value = "Cloudy")]
        Cloudy = 30,
    }
}