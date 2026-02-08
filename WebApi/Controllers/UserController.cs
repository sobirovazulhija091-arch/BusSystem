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
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(int userid,UpdateUserDto user)
    {
         return await service.UpdateAsync(userid,user);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int userid)
    {
         return await service.DeleteAsync(userid);
    }
     [HttpGet("userid")]
    public async Task<Response<User>> GetUserByIdAsync(int userid)
    {
         return await service.GetUserByIdAsync(userid);
    }
}