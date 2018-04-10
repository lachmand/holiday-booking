using System.Threading;
using System.Threading.Tasks;
using Domain.Events;
using HolidayBooking.Vacation.Contract.Vacation.Event;
using System.Text;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Holidaybooking.Vacation.Domain.Vacation.Handlers
{
    public class VacationEventHandler :
        IEventHandler<VacationCreated>
    {

        public VacationEventHandler()
        {
        }

        public async Task Handle(VacationCreated notification, CancellationToken cancellationToken = default(CancellationToken))
        {
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:9092" }
            };

            Producer<string, string> producer = null;
            try
            {
                producer = new Producer<string, string>(config, new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8));
                await producer.ProduceAsync("vacation.requested", notification.Id.ToString(), JsonConvert.SerializeObject(notification));

            }
            finally
            {
                if (producer != null)
                {
                    producer.Dispose();
                }
            }
        }
    }//class
}//ns