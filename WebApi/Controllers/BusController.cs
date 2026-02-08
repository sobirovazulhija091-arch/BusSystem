using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

[ApiController]
[Route("api/[controller]")]
public class BusController(IBusService service):ControllerBase
{
        [HttpPost]
         public async Task<Response<string>> AddAsync(BusDto busDto)
        {
                return await service.AddAsync(busDto);
        }
        [HttpPut]
        public async Task<Response<string>> UpdateAsync(int busid,UpadetBusDto busDto)
        {
                 return  await service.UpdateAsync(busid,busDto);
        }
        [HttpDelete]
        public async  Task<Response<string>> DeleteAsync(int busid)
        {
                return await service.DeleteAsync(busid);
        }
        [HttpGet("busid")]
        public async Task<Response<Bus>> GetBusByIdAsync(int busid)
        {
                return await service.GetBusByIdAsync(busid);
        }
        [HttpGet]
       public async Task<PagedResult<Bus>> GetAll([FromQuery]Busfilter filter,[FromQuery]PagedQuery pagedQuery)
        {
                return await service.GetAll(filter,pagedQuery);
        }
}
