using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController(IScheduleService service):ControllerBase
{
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
    [HttpPut]
      public async Task<Response<string>> UpdateAsync(int scheduleid,UpdateScheduleDto schedule)
    {
         return await service.UpdateAsync(scheduleid,schedule);
    }
     [HttpDelete]
      public async Task<Response<string>> DeleteAsync(int scheduleid)
    {
         return await service.DeleteAsync(scheduleid);
    }
     [HttpGet("scheduleid")]
    public async  Task<Response<Schedule>> GetScheduleByIdAsync(int scheduleid)
    {
         return await service.GetScheduleByIdAsync(scheduleid);
    }
}