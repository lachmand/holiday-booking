using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using HolidayBooking.VacationService.KafkaConsumer;

namespace HolidayBooking.VacationService
{
    public class VacationHandlerService : BackgroundService
    {
        private readonly ILogger<VacationHandlerService> _logger;
       
   
        public VacationHandlerService(ILogger<VacationHandlerService> logger)
        {
            //Constructor’s parameters validations...  
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"VacationHandlerService is starting.");

            stoppingToken.Register(() =>
                    _logger.LogDebug($" VacationHandlerService background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"VacationHandlerService task doing background work.");

                VacationKafkaConsumer consumer = new VacationKafkaConsumer();
                consumer.VacationEventHandler();

                await Task.Delay(50, stoppingToken);
            }

            _logger.LogDebug($"VacationHandlerService background task is stopping.");
        }
    }
}