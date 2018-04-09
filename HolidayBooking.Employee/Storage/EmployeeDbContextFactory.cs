using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace HolidayBooking.Employee.Storage
{
    public class EmployeeDbContextFactory: IDesignTimeDbContextFactory<EmployeeDbContext>
    {
        public EmployeeDbContextFactory(){}
        public EmployeeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>();

            if (optionsBuilder.IsConfigured)
                return new EmployeeDbContext(optionsBuilder.Options);

            //Called by parameterless ctor Usually Migrations
            var environmentName = Environment.GetEnvironmentVariable("EnvironmentName") ?? "Development";

            var connectionString =
                new ConfigurationBuilder()
                    //.SetBasePath(AppContext.BaseDirectory)
                    //.AddJsonFile("appsettings.json")
                    //.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: false)
                    //.AddEnvironmentVariables()
                    .Build()
                    .GetConnectionString("EmployeesDatabase");

            //optionsBuilder.UseNpgsql(connectionString);

            return new EmployeeDbContext(optionsBuilder.Options);
        }
    }
}