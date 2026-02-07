using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StopController(IStopService stopService):ControllerBase
{
    private IStopService service=stopService;
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
}