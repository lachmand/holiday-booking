using System;
using System.Text;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Threading.Tasks;

namespace HolidayBooking.VacationService.KafkaConsumer
{
    public class VacationKafkaConsumer
    {
        public VacationKafkaConsumer()
        {
        }

        public void VacationEventHandler()
        {
            var conf = new Dictionary<string, object>
            {
              { "group.id", "vacation-group" },
              { "bootstrap.servers", "localhost:9092" },
              { "auto.commit.interval.ms", 5000 },
              { "auto.offset.reset", "earliest" }
            };

            using (var consumer = new Consumer<Null, string>(conf, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnMessage += (_, msg)
                  => Console.WriteLine($"Read '{msg.Value}' from: {msg.TopicPartitionOffset}");

                consumer.OnError += (_, error)
                  => Console.WriteLine($"Error: {error}");

                consumer.OnConsumeError += (_, msg)
                  => Console.WriteLine($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");

                consumer.Subscribe("vacation.requested");

                while (true)
                {
                    consumer.Poll(TimeSpan.FromMilliseconds(100));
                }
            }
        }
    }//class
}//ns
