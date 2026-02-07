using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService):ControllerBase
{
    private IUserService service = userService;
    [HttpPost]
     public async Task<Response<string>> AddAsync(UserDto user)
    {
       return await service.AddAsync(user);
    }
    [HttpGet]
    public async Task<PagedResult<User>> GetUsersAsync([FromQuery]Userfilter filter,[FromQuery] PagedQuery pagedQuery)
    {
        return await service.GetUsersAsync(filter,pagedQuery);
    }
}