using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace HolidayBooking.Vacation.Storage
{
    public class VacationDbContextFactory : IDesignTimeDbContextFactory<VacationDbContext>
    {
        public VacationDbContextFactory() { }
        public VacationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VacationDbContext>();

            if (optionsBuilder.IsConfigured)
                return new VacationDbContext(optionsBuilder.Options);

            //Called by parameterless ctor Usually Migrations
            var environmentName = Environment.GetEnvironmentVariable("EnvironmentName") ?? "Development";

            var connectionString =
                new ConfigurationBuilder()
                    //.SetBasePath(AppContext.BaseDirectory)
                    //.AddJsonFile("appsettings.json")
                    //.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: false)
                    //.AddEnvironmentVariables()
                    .Build()
                    .GetConnectionString("VacationsDatabase");

            //optionsBuilder.UseNpgsql(connectionString);

            return new VacationDbContext(optionsBuilder.Options);
        }
    }
}