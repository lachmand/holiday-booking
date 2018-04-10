using System;
using Microsoft.Extensions.Options;
using HolidayBooking.VacationService.Model;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HolidayBooking.VacationService
{
    public class VacationRepository:IVacationRepository
    {
        private readonly VacationContext _context = null;

        public VacationRepository(IOptions<Settings> settings)
        {
            _context = new VacationContext(settings);
        }

        public async Task<IEnumerable<Model.Vacation>> GetAllVacations()
        {
            try
            {
                return await _context.Vacation
                        .FindAsync(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        //
        public async Task<Model.Vacation> GetVacation(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Vacation
                                     .FindAsync(vacation => vacation.Id == id
                                                || vacation.InternalId == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task AddVacation(Model.Vacation item)
        {
            try
            {
                await _context.Vacation.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveVacation(string id)
        {
            try
            {
                DeleteResult actionResult
                = await _context.Vacation.DeleteOneAsync(
                    Builders<Model.Vacation>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateVacation(string id, Model.Vacation item)
        {
            var filter = Builders<Model.Vacation>.Filter.Eq(s => s.Id, id);
            var update = Builders<Model.Vacation>.Update
                                       .Set(s => s.Status, item.Status)
                                       .Set(s => s.ApprovedBy, item.ApprovedBy)
                                       .Set(sim => sim.VacationPeriod, item.VacationPeriod)
                                       .CurrentDate(s => s.ChangedOn);

            try
            {
                UpdateResult actionResult
                = await _context.Vacation.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        public async Task<bool> RemoveAllVacations()
        {
            try
            {
                DeleteResult actionResult
                = await _context.Vacation.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

    }//class
}//ns
