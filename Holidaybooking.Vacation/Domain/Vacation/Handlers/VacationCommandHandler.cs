using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Events;
using Microsoft.EntityFrameworkCore;
using HolidayBooking.Vacation.Contract.Vacation.Command;
using HolidayBooking.Vacation.Contract.Vacation.Event;
using HolidayBooking.Vacation.Storage;

namespace Holidaybooking.Vacation.Domain.Vacation.Handlers
{
    public class VacationCommandHandler:
    ICommandHandler<CreateVacation>
    {
        private readonly IEventBus eventBus;

        public VacationCommandHandler(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }


        public async Task Handle(CreateVacation command, CancellationToken cancellationToken = default(CancellationToken))
        {
            //var id = command.Id ?? Guid.NewGuid();

            //await Vacations.AddAsync(new Vacation(
            //    id,
            //    command.Data.EmployeeId,
            //    new VacationPeriod(command.Data.Start, command.Data.End),
            //    Vacation.MapStatus (command.Data.Status),
            //    command.Data.ApprovedBy
            //));

            //await dbContext.SaveChangesAsync(cancellationToken);

            await eventBus.Publish(new VacationCreated(command.Data));
        }


    }//class
}//ns