using Finaktiva.Models;
using Finaktiva.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Finaktiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogsController : ControllerBase
    {
        private readonly IEventLogService _eventLogService;
        private readonly ILogger<EventLogsController> _logger;


        public EventLogsController(IEventLogService eventLogService, ILogger<EventLogsController> logger)
        {
            _eventLogService = eventLogService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<EventLog>> PostEventLog(EventLog eventLog)
        {
            try
            {
                var createdEvent = await _eventLogService.CreateEventAsync(eventLog);
                return CreatedAtAction(nameof(PostEventLog), new { id = createdEvent.Id }, createdEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the event.");
                return StatusCode(500, "An error occurred while creating the event.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventLog>>> GetEventLogs([FromQuery] string eventType, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            try
            {
                var events = await _eventLogService.GetEventsAsync(eventType, startDate, endDate);
                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving events.");
                return StatusCode(500, "An error occurred while retrieving events.");
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<EventLog>>> GetAllEventLogs()
        {
            try
            {
                var events = await _eventLogService.GetAllEventsAsync();
                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all events.");
                return StatusCode(500, "An error occurred while retrieving all events.");
            }
        }
    }
}
