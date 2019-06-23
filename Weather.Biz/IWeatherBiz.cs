namespace Weather.Biz
{
    public interface IWeatherBiz
    {
        Weather.Model.WeatherDTO GetWeatherInfo(double latitude, double longitude);
    }
}