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

            string vacationRequestNotification = JsonConvert.SerializeObject(notification);
            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                var dr=producer.ProduceAsync("vacation.requested", null, vacationRequestNotification).Result;
            }
        }
    }//class
}//ns