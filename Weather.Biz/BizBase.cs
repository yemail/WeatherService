using Weather.DAL;

namespace Weather.Biz
{
    public abstract class BizBase
    {
        public WeatherEntities weatherEntities;

        public BizBase()
        {
            if (this.weatherEntities == null)
            {
                weatherEntities = new WeatherEntities();
            }
        }
    }
}