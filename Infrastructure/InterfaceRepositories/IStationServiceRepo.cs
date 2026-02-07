public interface IStationServiceRepo
{
    
      Task<int> AddRepoAsync(Station station);
     Task<bool> UpdateRepoAsync(int stationid,Station station);
     Task<bool> DeleteRepoAsync(int stationid);
      Task<Station> GetStationByIdRepoAsync(int stationid);
     Task<List<Station>> GetStationsRepoAsync();
}