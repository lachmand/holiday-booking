using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HolidayBooking.VacationService.Model;

namespace HolidayBooking.VacationService
{
    public interface IVacationRepository
    {
        Task<IEnumerable<Model.Vacation>> GetAllVacations();
        Task<Model.Vacation> GetVacation(string id);

        Task AddVacation(Model.Vacation item);

        Task<bool> RemoveVacation(string id);

        Task<bool> UpdateVacation(string id, Model.Vacation vacation);

        Task<bool> RemoveAllVacation();    
    }//class
}//ns
