public interface IStopServiceRepo
{   
    Task<int> AddRepoAsync(Stop stop);
     Task<bool> UpdateRepoAsync(int stopid,UpdateStopDto stop);
     Task<bool> DeleteRepoAsync(int stopid);
      Task<Stop> GetStopByIdRepoAsync(int stopid);
     Task<List<Stop>> GetStopsRepoAsync();
}