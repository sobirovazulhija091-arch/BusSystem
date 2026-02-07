public interface IUserService
{
     Task<Response<string>> AddAsync(UserDto user);
     Task<Response<string>> UpdateAsync(int userid,UpdateUserDto user);
     Task<Response<string>> DeleteAsync(int userid);
     Task<Response<User>> GetUserByIdAsync(int userid);
     Task<PagedResult<User>> GetUsersAsync(Userfilter filter,PagedQuery pagedQuery);
}