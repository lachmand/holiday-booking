using System;
using System.Text;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HolidayBooking.Vacation.Contract.Vacation.Event;
using HolidayBooking.Vacation.Contract.Vacation.Command;
using System.Net.Http;


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
                  =>
                {
                    VacationCreated vacationCreated = JsonConvert.DeserializeObject<VacationCreated>(msg.Value);
                    Console.WriteLine($"Read '{msg.Value}' from: {msg.TopicPartitionOffset}");

                    //write to mongodb
                    WriteToMongoDb(vacationCreated);

                    //raise message in Kafka
                    PublishEvent("vacation.request.received", vacationCreated);

                };

                consumer.OnError += (_, error)
                  => Console.WriteLine($"Error: {error}");

                consumer.OnConsumeError += (_, msg)
                  => Console.WriteLine($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");

                consumer.Subscribe("vacation.requested");
            }
        }

        void WriteToMongoDb(VacationCreated vacationCreated)
        {
            // Create a New HttpClient object.
            HttpClient client = new HttpClient();

            CreateVacation createVacation = new CreateVacation(vacationCreated.Id, vacationCreated.Data);

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                client.PostAsync("http://v1/api/vacationHandler/Vacation", new JsonContent(createVacation)).Wait();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            // Need to call dispose on the HttpClient object
            // when done using it, so the app doesn't leak resources
            client.Dispose();

        }

        void PublishEvent(string eventId, VacationCreated vacationCreated)
        {

            var config = new Dictionary<string, object>
                {
                    { "bootstrap.servers", "localhost:9092" }
                };

            Producer<string, string> producer = null;
            try
            {
                producer = new Producer<string, string>(config, new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8));
                producer.ProduceAsync("vacation.request.received", vacationCreated.Id.ToString(), JsonConvert.SerializeObject(vacationCreated));
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
