using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Events;
using Microsoft.EntityFrameworkCore;
using HolidayBooking.Vacation.Contract.Vacation.Command;
using HolidayBooking.Vacation.Storage;

namespace Holidaybooking.Vacation.Domain.Vacation.Handlers
{
    public class VacationCommandHandler:
    ICommandHandler<HolidayBooking.Vacation.Contract.Vacation.Command.ApproveVacation> //ApproveVacation>,
    {
        private readonly HolidayBooking.Vacation.Storage.VacationDbContext dbContext;
        private readonly IEventBus eventBus;

        private DbSet<Vacation> Vacations;

        public VacationCommandHandler(VacationDbContext dbContext, IEventBus eventBus)
        {
            this.dbContext = dbContext;
            Vacations = dbContext.Vacations;
            this.eventBus = eventBus;
        }

        public async Task Handle(ApproveVacation command, CancellationToken cancellationToken = default(CancellationToken))
        {
        }
    }
}