using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using MediatR;
using Domain.Commands;
using Domain.Events;
using Domain.Queries;
using Domain.Aggregates;
using HolidayBooking.Vacation.Contract.Vacation.Command;
using HolidayBooking.Vacation.Contract.Vacation.Query;
using HolidayBooking.Vacation.Contract.Vacation.ValueObject;
using HolidayBooking.Vacation.Contract.Vacation.Event;
using Holidaybooking.Vacation.Domain.Vacation.Handlers;



namespace holiday_booking_service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "holiday-booking-service", Version = "v1" });
            });

            //services.AddTransient<IAccountNumberGenerator, RandomAccountNumberGenerator>();

            ConfigureMediator(services);

            ConfigureCQRS(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "holiday-booking-service V1");
            });
        }

        private static void ConfigureMediator(IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddTransient<SingleInstanceFactory>(sp => t => sp.GetService(t));
            services.AddTransient<MultiInstanceFactory>(sp => t => sp.GetServices(t));
        }

        private static void ConfigureCQRS(IServiceCollection services)
        {
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();

            services.AddScoped<IRequestHandler<CreateVacation>, VacationCommandHandler>();

            services.AddScoped<INotificationHandler<VacationCreated>, VacationEventHandler>();
 
         }
    }//class
}//ns
