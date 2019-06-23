using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace Weather.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IContainer autoFacContainer = null;

        protected IContainer AutoFacContainer
        {
            get { return autoFacContainer; }
            set { autoFacContainer = value; }
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Weather.Biz.WeatherBiz>().As<Weather.Biz.IWeatherBiz>().InstancePerRequest();
            AutoFacContainer = builder.Build();

            //Create dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(AutoFacContainer);
        }
    }
}