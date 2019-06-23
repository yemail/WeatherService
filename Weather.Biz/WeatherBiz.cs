using AutoMapper;
using System.Data.Entity.Spatial;
using System.Linq;
using Weather.Model;

namespace Weather.Biz
{
    public class WeatherBiz : BizBase, IWeatherBiz
    {
        public Weather.Model.WeatherDTO GetWeatherInfo(double latitude, double longitude)
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Spatial, Model.Spatial>().MaxDepth(2);
                cfg.CreateMap<DAL.Weather, Model.Weather>().MaxDepth(2);
                cfg.CreateMap<DAL.Wind_Levels, Model.Wind_Levels>().MaxDepth(2);
                cfg.CreateMap<DAL.Wind_Directions, Model.Wind_Directions>().MaxDepth(2);
                cfg.CreateMap<DAL.Weather_Types, Model.Weather_Types>().MaxDepth(2);
                cfg.CreateMap<DAL.Air_Quality_Types, Model.Air_Quality_Types>().MaxDepth(2);
                cfg.CreateMap<DAL.Location_Aware_Message, Model.Location_Aware_Message>().MaxDepth(2);
            });
            var mapper = mapperConfig.CreateMapper();
            var coord = DbGeography.FromText($"Point({longitude} {latitude})", 4326);
            var nearestCity = mapper.Map<Model.Spatial>((from p in weatherEntities.Spatials

                                                         orderby p.GeoLocation.Distance(coord)
                                                         select p).FirstOrDefault());
            if (nearestCity != null)
            {
                var weatherOfCity = mapper.Map<Model.Weather>(weatherEntities.Weathers.Where(a => a.Spatial_Id == nearestCity.Spatial_Id).FirstOrDefault());
                if (weatherOfCity != null)
                {
                    weatherOfCity.Spatial = nearestCity;
                    weatherOfCity.Weather_Types = mapper.Map<Model.Weather_Types>(weatherEntities.Weather_Types.Where(a => a.Weather_Type_Id == weatherOfCity.Weather_Type_Id).FirstOrDefault());
                    weatherOfCity.Wind_Directions = mapper.Map<Model.Wind_Directions>(weatherEntities.Wind_Directions.Where(a => a.Wind_Direction_Id == weatherOfCity.Wind_Direction_Id).FirstOrDefault());
                    Model.Wind_Levels windLevel = mapper.Map<Model.Wind_Levels>(weatherEntities.Wind_Levels.Where(a => weatherOfCity.Wind_Speed != null && a.Speed_Start <= weatherOfCity.Wind_Speed && a.Speed_End > weatherOfCity.Wind_Speed).FirstOrDefault());
                    Model.Air_Quality_Types airQuality = mapper.Map<Model.Air_Quality_Types>(weatherEntities.Air_Quality_Types.Where(a => weatherOfCity.Air_Quality_Num != null && a.Start <= weatherOfCity.Air_Quality_Num && a.End > weatherOfCity.Air_Quality_Num).FirstOrDefault());
                    Model.Location_Aware_Message msg = mapper.Map<Model.Location_Aware_Message>(weatherEntities.Location_Aware_Message.Where(a => a.Spatial_Id == nearestCity.Spatial_Id).FirstOrDefault());
                    Model.WeatherDTO weatherDto = new WeatherDTO(weatherOfCity, windLevel, airQuality, msg);

                    return weatherDto;
                }
            }
            return null;
        }
    }
}