using Android.App;
using Android.Locations;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Weather.Andriod;

namespace Weather.Andriod
{
    [Activity(Label = "Weather", MainLauncher = true)]
    public class MainActivity : Activity, ILocationListener
    {
        private LocationManager _locationManager;
        private string _locationProvider;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            InitializeLocationManager();
        }

        private void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            Criteria locationCriteria = new Criteria();
            locationCriteria.Accuracy = Accuracy.Coarse;
            locationCriteria.PowerRequirement = Power.NoRequirement;
            string locationProvider = _locationManager.GetBestProvider(locationCriteria, true);
            if (!String.IsNullOrEmpty(locationProvider))
            {
                _locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        public async void OnLocationChanged(Location location)
        {
            WebClient client = new WebClient();
            string url = GetString(Resource.String.WeatherServiceLoc) + "?latitude=" + location.Latitude + "&longitude=" + location.Longitude;
            Uri uri = new Uri(url);
            string result = null;
            bool downloaded;
            try
            {
                result = await client.DownloadStringTaskAsync(uri);
                downloaded = true;
            }
            catch
            {
                downloaded = false;
            }
            if (downloaded)
            {
                ParseAndDisplay(result);
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }

        private void ParseAndDisplay(String json)
        {
            Weather.Android.Model.WeatherDTO weather = Newtonsoft.Json.JsonConvert.DeserializeObject<Weather.Android.Model.WeatherDTO>(json);
            if (weather != null)
            {
                TextView tvLocation = FindViewById<TextView>(Resource.Id.tvLocation);
                TextView tvTemperature = FindViewById<TextView>(Resource.Id.tvTemperature);
                TextView tvHumidityInfo = FindViewById<TextView>(Resource.Id.tvHumidityInfo);
                TextView tvAirQualityInfo = FindViewById<TextView>(Resource.Id.tvAirQualityInfo);
                TextView tvAirQualityNum = FindViewById<TextView>(Resource.Id.tvAirQualityNum);
                TextView tvFeelLike = FindViewById<TextView>(Resource.Id.tvFeelLike);
                TextView tvHumidityTitle = FindViewById<TextView>(Resource.Id.tvHumidityTitle);
                TextView tvTimeZone = FindViewById<TextView>(Resource.Id.tvTimeZone);
                TextView tvWeatherType = FindViewById<TextView>(Resource.Id.tvWeatherType);
                TextView tvWelcomeInfo = FindViewById<TextView>(Resource.Id.tvWelcomeInfo);
                TextView tvWindInfo = FindViewById<TextView>(Resource.Id.tvWindInfo);
                TextView tvWindTitle = FindViewById<TextView>(Resource.Id.tvWindTitle);
                ImageView imgWeatherType = FindViewById<ImageView>(Resource.Id.imgWeatherType);
                ImageView imageMS = FindViewById<ImageView>(Resource.Id.imageMS);
                tvLocation.Text = weather.City + ", " + weather.Country;
                tvTemperature.Text = weather.Temperature.ToString() + "бу";
                tvAirQualityInfo.Text = "Air Quality (" + weather.AirQuailty + ")";
                tvWeatherType.Text = weather.Weather_Type;
                tvAirQualityNum.Text = weather.Air_Quality_Num.ToString();
                tvFeelLike.Text = "Feels Like " + weather.Temperature_Feels.ToString() + "бу";
                tvHumidityInfo.Text = weather.Humidity.ToString() + "%";
                tvTimeZone.Text = " " + TimeZone.CurrentTimeZone.DaylightName;
                tvWelcomeInfo.Text = weather.ExtraInfo;
                tvWindInfo.Text = " Level:" + weather.WindLeveL + " " + weather.WindDirection + " " + weather.Wind_Speed + "km/h ";
                if (weather.Weather_Type_Id == (int)(Weather.Android.Model.WeatherTypesEnum.Cloudy))
                {
                    imgWeatherType.SetImageResource(Resource.Drawable.Cloudy);
                }
                else if
                    (weather.Weather_Type_Id == (int)(Weather.Android.Model.WeatherTypesEnum.Sunny))
                {
                    imgWeatherType.SetImageResource(Resource.Drawable.Sunny);
                }
                else if (weather.Weather_Type_Id == (int)(Weather.Android.Model.WeatherTypesEnum.Rainy))
                {
                    imgWeatherType.SetImageResource(Resource.Drawable.Rainy);
                }

                imageMS.SetImageResource(Resource.Drawable.microsoft);
            }
        }
    }
}