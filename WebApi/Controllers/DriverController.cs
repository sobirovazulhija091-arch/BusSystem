using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DriverController(IDriverService service):ControllerBase
{
    
    [HttpPost]
     public async Task<Response<string>> AddAsync(DriverDto driver)
    {
         return await service.AddAsync(driver);
    }
    [HttpGet]
     public async Task<PagedResult<Driver>> GetDriversAsync([FromQuery]Driverfilter filter,[FromQuery]PagedQuery pagedQuery)
    {
        return await service.GetDriversAsync(filter,pagedQuery);
    }
    [HttpPut]
   public async Task<Response<string>> UpdateAsync(int driverid,UpdateDriverDto driver)
    {
        return await service.UpdateAsync(driverid,driver);
    }
    [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int driverid)
    {
         return await service.DeleteAsync(driverid);
    }
    [HttpGet("driverid")]
     public async  Task<Response<Driver>> GetDriverByIdAsync(int driverid)
    {
         return await service.GetDriverByIdAsync(driverid);
    }
}