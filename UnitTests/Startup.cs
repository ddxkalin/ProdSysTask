using Persistence.Repository.Address;
using Persistence.Repository.Employee;
using Persistence.Repository.Position;
using Application.Services.EmployeeService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

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
