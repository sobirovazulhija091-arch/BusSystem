using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DriverController(IDriverService driverService):ControllerBase
{
    private IDriverService service= driverService;
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
}