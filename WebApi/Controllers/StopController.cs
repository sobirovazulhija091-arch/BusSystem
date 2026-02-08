using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StopController(IStopService service):ControllerBase
{
 
    [HttpPost]
       public async Task<Response<string>> AddAsync(StopDto stop)
    {
       return await service.AddAsync(stop); 
    } 
    [HttpGet]
      public async Task<PagedResult<Stop>> GetStopsAsync([FromQuery]Stopfilter filter,[FromQuery] PagedQuery pagedQuery)
    {
        return await service.GetStopsAsync(filter,pagedQuery);
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(int stopid,UpdateStopDto stop)
    {
         return await service.UpdateAsync(stopid,stop);
    }
     [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int stopid)
    {
         return await service.DeleteAsync(stopid);
    }
     [HttpGet("'stopid")]
     public async  Task<Response<Stop>> GetStopByIdAsync(int stopid)
    {
         return await service.GetStopByIdAsync(stopid);
    }
}