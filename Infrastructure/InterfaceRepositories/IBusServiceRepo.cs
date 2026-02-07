public interface IBusServiceRepo
{
     Task<int> AddRepoAsync(Bus bus);
     Task<bool> UpdateRepoAsync(int busid,Bus bus);
     Task<bool> DeleteRepoAsync(int busid);
     Task<Bus> GetBusByIdRepoAsync(int busid);
     Task<List<Bus>> GetBusesRepoAsync();
}