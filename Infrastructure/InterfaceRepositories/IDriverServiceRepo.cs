using System.Security.Cryptography.X509Certificates;
public interface IDriverServiceRepo
{
    Task<int> AddRepoAsync(Driver driver);
    Task<bool> UpdateRepoAsync(int driverid,Driver driver);
     Task<bool> DeleteRepoAsync(int driverid);
    Task<Driver> GetDriverByIdRepoAsync(int driverid);
    Task<List<Driver>> GetDriversRepoAsync();
}