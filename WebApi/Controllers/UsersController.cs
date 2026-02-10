using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController(JwtService jwtService):ControllerBase
{
    private readonly JwtService _jwtService=jwtService;
    [HttpPost("login")]
public IActionResult Login(LonginDto dto)
{
    if(dto.Username == "admin@mail.com"
       && dto.Password == "1234")
    {
        var token = _jwtService.GenerateToken(1, dto.Username);
        return Ok(token);
    }

    return Unauthorized();
}
[Authorize]
[HttpGet("profile")]
public string GetProfile()
{
    return "Secret profile data";
}
}
