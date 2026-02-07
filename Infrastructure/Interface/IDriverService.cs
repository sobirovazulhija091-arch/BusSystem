using System.Security.Cryptography.X509Certificates;
public interface IDriverService
{
    Task<Response<string>> AddAsync(DriverDto driver);
    Task<Response<string>> UpdateAsync(int driverid,UpdateDriverDto driver);
     Task<Response<string>> DeleteAsync(int driverid);
     Task<Response<Driver>> GetDriverByIdAsync(int driverid);
    Task<PagedResult<Driver>> GetDriversAsync(Driverfilter filter,PagedQuery pagedQuery);
}