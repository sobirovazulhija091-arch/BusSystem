using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BusController(IBusService busService):ControllerBase
{
        private IBusService service=busService;
        [HttpPost]
         public async Task<Response<string>> AddAsync(BusDto busDto)
        {
                return await service.AddAsync(busDto);
        }
}
