using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController(IScheduleService scheduleService):ControllerBase
{
    private IScheduleService service = scheduleService;
    [HttpPost]
     public async Task<Response<string>> AddAsync(ScheduleDto schedule)
    {
       return await service.AddAsync(schedule);
    }
    [HttpGet]
     public async Task<PagedResult<Schedule>> GetSchedulesAsync([FromQuery]Schedulefilter filter, [FromQuery]PagedQuery pagedQuery)
    {
        return await service.GetSchedulesAsync(filter,pagedQuery);
    }
}