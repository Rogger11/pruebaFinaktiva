using Microsoft.EntityFrameworkCore;

namespace Finaktiva.Models
{
    public class EventLogContext : DbContext
    {
        public EventLogContext(DbContextOptions<EventLogContext> options)
            : base(options)
        {
        }

        public DbSet<EventLog> EventLogs { get; set; }
    }
}
