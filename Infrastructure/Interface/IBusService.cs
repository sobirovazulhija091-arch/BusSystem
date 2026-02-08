public interface IBusService
{
     Task<Response<string>> AddAsync(BusDto busDto);
     Task<Response<string>> UpdateAsync(int busid,UpadetBusDto busDto);
     Task<Response<string>> DeleteAsync(int busid);
     Task<Response<Bus>> GetBusByIdAsync(int busid);
    Task<PagedResult<Bus>> GetAll(Busfilter filter,PagedQuery pagedQuery);
     
}