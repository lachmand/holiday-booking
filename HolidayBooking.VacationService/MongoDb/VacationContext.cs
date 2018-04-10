using System;
using MongoDB;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using HolidayBooking.VacationService.Model;

namespace HolidayBooking.VacationService
{
    public class VacationContext
    {
        private readonly IMongoDatabase _database = null;

        public VacationContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<VacationService.Model.Vacation> Vacation
        {
            get
            {
                return _database.GetCollection<Model.Vacation>("Vacation");
            }
        }
    }//class
}//ns
