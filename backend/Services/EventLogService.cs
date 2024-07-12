using Finaktiva.Models;
using Finaktiva.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finaktiva.Services
{
    public class EventLogService : IEventLogService
    {
        private readonly EventLogContext _context;
        private readonly ILogger<EventLogService> _logger;

        public EventLogService(EventLogContext context, ILogger<EventLogService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<EventLog> CreateEventAsync(EventLog eventLog)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.EventLogs.Add(eventLog);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return eventLog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the event.");
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<EventLog>> GetEventsAsync(string eventType, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var query = _context.EventLogs.AsQueryable();

                if (!string.IsNullOrEmpty(eventType))
                {
                    query = query.Where(e => e.EventType == eventType);
                }

                if (startDate.HasValue && endDate.HasValue)
                {
                    query = query.Where(e => e.EventDate >= startDate.Value && e.EventDate <= endDate.Value);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving events.");
                throw;
            }
        }
        public async Task<IEnumerable<EventLog>> GetAllEventsAsync()
        {
            try
            {
                return await _context.EventLogs.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all events.");
                throw;
            }
        }
    }
}
