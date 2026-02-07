
using Microsoft.EntityFrameworkCore;
using System.Net;
public class StopService(ApplicationDbcontext dbcontext):IStopService
{
     private readonly ApplicationDbcontext context = dbcontext;

    public async Task<Response<string>> AddAsync(StopDto stop)
    {
        var stop1 = new Stop
        {
            StopName=stop.StopName,
            Location=stop.Location
        };
         await context.Stops.AddAsync(stop1);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.Created," Created Successfully");
    }

    public Task<Response<string>> DeleteAsync(int stopid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Stop>> GetStopByIdAsync(int stopid)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<Stop>> GetStopsAsync(Stopfilter filter, PagedQuery pagedQuery)
    {
         IQueryable<Stop> query = context.Stops.AsNoTracking();
         if(filter.Location!=null)
        {
            query = query.Where(x=>x.Location==filter.Location);
        }
         if(filter.StopName!=null)
        {
            query = query.Where(x=>x.StopName==filter.StopName);
        }
        var total = await  query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var stops = query.ToList();
        var response = new PagedResult<Stop>()
        {
            Items = stops,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
            TotalPages = total/pagedQuery.PageSize
        }; 
        return response;
    }

    public Task<Response<List<Stop>>> SearchStopByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateAsync(int stopid, UpdateStopDto stop)
    {
        throw new NotImplementedException();
    }
}