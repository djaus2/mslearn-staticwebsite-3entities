using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Api
{
    public class ActivityHelpersContextFactory : IDesignTimeDbContextFactory<ActivityHelpersContext>
    {
        //public Startup(IConfiguration configuration)
        //{
        //    System.Diagnostics.Debug.WriteLine($"XXX 1");
        //    Configuration = configuration;
        //    System.Diagnostics.Debug.WriteLine($"XXX 2");
        //}

        public IConfiguration Configuration { get; }
        public ActivityHelpersContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            var connectionstrings = config.GetSection("ConnectionStrings");

            //var yy = (string)connectionstrings["DefaultConnection"];
            string SqlConnection = connectionstrings.GetValue<string>("DefaultConnection");

            //string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<ActivityHelpersContext>();

            //optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnection"));
            optionsBuilder.UseSqlServer(
                    SqlConnection);
            return new ActivityHelpersContext(optionsBuilder.Options);
        }
    }
}
