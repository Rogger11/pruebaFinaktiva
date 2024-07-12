using System.Collections.Generic;
using System.Threading.Tasks;
using Finaktiva.Models;

namespace Finaktiva.Services
{
    public interface IEventLogService
    {
        Task<EventLog> CreateEventAsync(EventLog eventLog);
        Task<IEnumerable<EventLog>> GetEventsAsync(string eventType, DateTime? startDate, DateTime? endDate);
        Task<IEnumerable<EventLog>> GetAllEventsAsync();
    }
}
