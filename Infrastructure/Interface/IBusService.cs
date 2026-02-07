public interface IBusService
{
     Task<Response<string>> AddAsync(BusDto busDto);
     Task<Response<string>> UpdateAsync(int busid,UpadetBusDto busDto);
     Task<Response<string>> DeleteAsync(int busid);
     Task<Response<Bus>> GetBusByIdAsync(int busid);
    Task<Response<List<Bus>>> GetBusesByTypeAsync(EnumBusType busType);
    Task<Response<List<Bus>>> GetBusesByPathAsync(int pathId);
    Task<Response<List<Bus>>> GetBusesByStopAsync(int stopId);
    Task<Response<List<Bus>>> SortBusesByArrivalTimeAsync(int stopId);
     
}