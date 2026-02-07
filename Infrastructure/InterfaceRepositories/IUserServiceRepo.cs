public interface IUserServiceRepo
{
     Task<int> AddRepoAsync(User user);
     Task<bool> UpdateRepoAsync(int userid,User user);
     Task<bool> DeleteRepoAsync(int userid);
     Task<User> GetUserByIdRepoAsync(int userid);
     Task<List<User>> GetUsersRepoAsync();
}