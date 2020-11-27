using Autofac;
using BridgeInternationalAcademies.BAL.Interfaces;
using BridgeInternationalAcademies.BAL.Services;
using Microsoft.Extensions.Configuration;

namespace BridgeInternationalAcademies.WebAPI
{
    public class DependencyRegistration
    {
        private IConfiguration _configuration;

        public DependencyRegistration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void RegisterBALTypes(ContainerBuilder builder)
        {
            builder.RegisterType<BatteryUsageService>().As<IBatteryUsageService>();
        }
    }
}
