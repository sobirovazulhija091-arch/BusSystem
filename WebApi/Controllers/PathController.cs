using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PathController(IPathService pathService):ControllerBase
{
    private IPathService service = pathService;
    [HttpPost]
       public  async Task<Response<string>> AddAsync(PathDto path)
    {
         return await service.AddAsync(path);
    }
    [HttpGet]
     public async Task<PagedResult<Path>> GetPathsAsync([FromQuery]Pathfilter filter,[FromQuery] PagedQuery pagedQuery)
    {
        return await service.GetPathsAsync(filter,pagedQuery);
    }
}