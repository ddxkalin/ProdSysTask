using Persistence.Repository.Address;
using Persistence.Repository.Employee;
using Persistence.Repository.Position;
using Application.Services.EmployeeService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

namespace UnitTests
{
    public class Startup 
    {
        public void ConfigureHost(IHostBuilder hostBuilder) =>
       hostBuilder
           .ConfigureHostConfiguration(builder => { builder.AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true).Build(); })
           .ConfigureAppConfiguration((context, builder) => { });


        public void ConfigureServices(IServiceCollection services)
        {
            //DI services
            services.AddSingleton<DataContext>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

        }

    }
}
