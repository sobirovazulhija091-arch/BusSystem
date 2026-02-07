using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StationController(IStationService stationService):ControllerBase
{
    private IStationService service=stationService;
    [HttpPost]
     public async Task<Response<string>> AddAsync(StationDto station)
    {
       return await service.AddAsync(station);
    }
    [HttpGet]
      public async Task<PagedResult<Station>> GetStationsAsync([FromQuery]Stationfilter filter, [FromQuery]PagedQuery pagedQuery)
    {
        return await  service.GetStationsAsync(filter,pagedQuery);
    }
}