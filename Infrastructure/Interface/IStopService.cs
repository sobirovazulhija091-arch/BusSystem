public interface IStopService
{   
    Task<Response<string>> AddAsync(StopDto stop);
     Task<Response<string>> UpdateAsync(int stopid,UpdateStopDto stop);
     Task<Response<string>> DeleteAsync(int stopid);
      Task<Response<Stop>> GetStopByIdAsync(int stopid);
     Task<PagedResult<Stop>> GetStopsAsync(Stopfilter filter,PagedQuery pagedQuery);
     Task<Response<List<Stop>>> SearchStopByNameAsync(string name);
}