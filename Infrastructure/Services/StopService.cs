
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
        return new Response<string>(HttpStatusCode.OK," Created Successfully");
    }

    public async Task<Response<string>> DeleteAsync(int stopid)
    {
          var del = await context.Stops.FindAsync(stopid);
        context.Stops.Remove(del);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }

    public async Task<Response<Stop>> GetStopByIdAsync(int stopid)
    {
          var stop = await context.Stops.FirstOrDefaultAsync(x => x.Id == stopid);
    if (stop == null)
    {
        return new Response<Stop>(HttpStatusCode.NotFound,"Driver not found");
    }  
        return new Response<Stop>(HttpStatusCode.OK,"OK",stop);
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

    public async Task<Response<List<Stop>>> SearchStopByNameAsync(string name)
    {
        var stop = await context.Stops.Where(x=>x.StopName.Contains(name)).ToListAsync();
        return new Response<List<Stop>>(HttpStatusCode.OK, "OK",stop);
    }

    public async Task<Response<string>> UpdateAsync(int stopid, UpdateStopDto stop)
    {
        var s = await context.Stops.FindAsync(stopid);
        s.StopName=stop.StopName;
        s.Location=stop.Location;
       await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Update successfull");
    }
}