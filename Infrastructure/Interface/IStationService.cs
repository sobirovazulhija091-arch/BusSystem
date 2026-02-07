public interface IStationService
{
    
      Task<Response<string>> AddAsync(StationDto station);
     Task<Response<string>> UpdateAsync(int stationid,UpdateStationDto station);
     Task<Response<string>> DeleteAsync(int stationid);
      Task<Response<Station>> GetStationByIdAsync(int stationid);
     Task<PagedResult<Station>> GetStationsAsync(Stationfilter filter,PagedQuery pagedQuery);
}