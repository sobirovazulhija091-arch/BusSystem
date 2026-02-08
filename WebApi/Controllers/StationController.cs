using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StationController(IStationService service):ControllerBase
{
    
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
    [HttpPut]
    public async  Task<Response<string>> UpdateAsync(int stationid,UpdateStationDto station)
    {
        return await  service.UpdateAsync(stationid,station);
    }
      [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int stationid)
    {
        return await  service.DeleteAsync(stationid);
    }
     [HttpGet("stationid")]
    public async  Task<Response<Station>> GetStationByIdAsync(int stationid)
    {
        return await  service.GetStationByIdAsync(stationid);
    }
}