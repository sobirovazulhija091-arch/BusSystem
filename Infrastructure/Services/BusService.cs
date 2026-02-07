using System.Net;
using Npgsql.Replication;

public class BusService(IBusServiceRepo busServiceRepo) : IBusService
{
    private readonly IBusServiceRepo busrepo = busServiceRepo;
    public async Task<Response<string>> AddAsync(BusDto busDto)
    {
        var bus = new Bus
        {
          Number=busDto.Number,
          BusType=busDto.BusType,
          Capacity=busDto.Capacity,
          CurrentOccupancy=busDto.CurrentOccupancy,
          Price=busDto.Price  
        };
        await busrepo.AddRepoAsync(bus);
         return new Response<string>(HttpStatusCode.Created,"Bus Created Successfully");
    }

    public  async Task<Response<string>> DeleteAsync(int busid)
    {
        try
        {
             var del = busrepo.DeleteRepoAsync(busid);
        return new Response<string>(HttpStatusCode.OK,"Deleted successfully");
        }
        catch (System.Exception)
        {
            return new Response<string>(HttpStatusCode.NoContent," There is no Id");
        }
    }

    public async Task<Response<Bus>> GetBusByIdAsync(int busid)
    {
       var bus = await busrepo.GetBusByIdRepoAsync(busid);
       return new Response<Bus>(HttpStatusCode.OK,"OK",bus);
    }

    public Task<Response<List<Bus>>> GetBusesByPathAsync(int pathId)
    {
        throw new NotImplementedException();
    } 

    public Task<Response<List<Bus>>> GetBusesByStopAsync(int stopId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<Bus>>> GetBusesByTypeAsync(EnumBusType busType)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<Bus>>> SortBusesByArrivalTimeAsync(int stopId)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateAsync(int busid, UpadetBusDto busDto)
    {
        throw new NotImplementedException();
    }
}