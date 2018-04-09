using System.Threading;
using System.Threading.Tasks;
using Domain.Events;
using HolidayBooking.Vacation.Contract.Vacation.Event;

namespace EventSourcing.Sample.Transactions.Domain.Clients.Handlers
{
    public class ClientsEventHandler :
        IEventHandler<VacationCreated>
    {
        
        public ClientsEventHandler()
        {
        }

        public Task Handle(VacationCreated @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            await;
            //todo
        }
    }
}