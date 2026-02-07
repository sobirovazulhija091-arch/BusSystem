
public class DriverServiceRepo(ApplicationDbcontext dbcontext):IDriverServiceRepo
{
    private readonly ApplicationDbcontext context  = dbcontext;

    public async Task<int> AddRepoAsync(Driver driver)
    {
       throw new NotImplementedException();
    }

    public Task<bool> DeleteRepoAsync(int driverid)
    {
        throw new NotImplementedException();
    }

    public Task<Driver> GetDriverByIdRepoAsync(int driverid)
    {
        throw new NotImplementedException();
    }

    public Task<List<Driver>> GetDriversRepoAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRepoAsync(int driverid, Driver driver)
    {
        throw new NotImplementedException();
    }
}