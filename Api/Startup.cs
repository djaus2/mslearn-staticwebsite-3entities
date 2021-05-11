using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

using System;
using System.Configuration;
using System.IO;

[assembly: FunctionsStartup(typeof(Api.Startup))]

namespace Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var config1 = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            string SqlConnection =  config1.GetValue<string>("DefaultConnection");

            if (string.IsNullOrEmpty(SqlConnection))
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
 
                var connectionstrings = config.GetSection("ConnectionStrings");
                SqlConnection = connectionstrings.GetValue<string>("DefaultConnection");
            }

           builder.Services.AddDbContext<ActivityHelpersContext>(options =>
                options.UseSqlServer(SqlConnection));
        }
    }
}
