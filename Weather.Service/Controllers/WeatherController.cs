using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Weather.Biz;

namespace Weather.Service.Controllers
{
    public class WeatherController : ApiControllerBase
    {
        public WeatherController()
        {
        }

        public WeatherController(IWeatherBiz weatherBiz)
        {
            _weatherBiz = weatherBiz;
        }

        private readonly IWeatherBiz _weatherBiz;

        [HttpGet]
        [Route("currentWeather")]
        public HttpResponseMessage GetWeather(String latitude, String longitude)
        {
            double lat = 0;
            double longit = 0;

            Double.TryParse(latitude, out lat);
            Double.TryParse(longitude, out longit);
            return
                GetHttpResponse(
                    () => Request.CreateResponse(HttpStatusCode.OK,
                        _weatherBiz.GetWeatherInfo(lat, longit)));
        }
    }
}