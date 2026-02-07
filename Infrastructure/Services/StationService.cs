
using Microsoft.EntityFrameworkCore;
using System.Net;
public class StationService(ApplicationDbcontext dbcontext):IStationService
{
     private readonly ApplicationDbcontext context = dbcontext;

    public async Task<Response<string>> AddAsync(StationDto station)
    {
        var station1 = new Station
        {
            Name=station.Name,
            PathId=station.PathId,
            StopId=station.StopId
        };
        await context.Stations.AddAsync(station1);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.Created," Created Successfully");
    }

    public Task<Response<string>> DeleteAsync(int stationid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Station>> GetStationByIdAsync(int stationid)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<Station>> GetStationsAsync(Stationfilter filter, PagedQuery pagedQuery)
    {
        IQueryable<Station> query = context.Stations.AsNoTracking();
        if (filter.Name != null)
        {
            query = query.Where(x=>x.Name==filter.Name);
        }
        var total = await  query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var station = query.ToList();
        var response = new PagedResult<Station>()
        {
            Items = station,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
            TotalPages = total/pagedQuery.PageSize
        }; 
        return response;
    }

    public Task<Response<string>> UpdateAsync(int stationid, UpdateStationDto station)
    {
        throw new NotImplementedException();
    }
}