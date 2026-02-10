using System.Net;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;

public class BusService(ApplicationDbcontext dbcontext) : IBusService
{
    private readonly  ApplicationDbcontext context = dbcontext;
    public async Task<Response<string>> AddAsync(BusDto busDto)
    {
        var bus = new Bus
        {
          Number=busDto.Number,
          BusType=(EnumBusType)busDto.BusType,
          Capacity=busDto.Capacity,
          CurrentOccupancy=busDto.CurrentOccupancy,
          Price=busDto.Price  
        };
         await context.Buses.AddAsync(bus);
        await context.SaveChangesAsync();
      return new Response<string>(HttpStatusCode.OK,"Bus Created Successfully");
    }

    public  async Task<Response<string>> DeleteAsync(int busid)
    {
        try
        {
         var del = await context.Buses.FindAsync(busid);
          context.Buses.Remove(del);
          await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Deleted successfully");
        }
        catch (System.Exception)
        {
            return new Response<string>(HttpStatusCode.NoContent," There is no Id");
        }
    }

    public async Task<Response<Bus>> GetBusByIdAsync(int busid)
    {
       var  bus =  context.Buses.Include(a=>a.Schedules).First(a=>a.Id==busid);
       if (bus == null)
    {
        return new Response<Bus>(HttpStatusCode.NotFound,"Bus not found");
    }
    return new Response<Bus>(HttpStatusCode.OK,"OK",bus
    );
    }
    
    public async Task<Response<string>> UpdateAsync(int busid, UpadetBusDto busDto)
    {
       var bus = await context.Buses.FindAsync(busid);
        bus.BusType=(EnumBusType)busDto.BusType;
        bus.CurrentOccupancy=busDto.CurrentOccupancy;
        bus.Capacity=busDto.Capacity;
        bus.Number=busDto.Number;
        bus.Price=busDto.Price;
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Update successfull");
    }
    public async Task<PagedResult<Bus>> GetAll(Busfilter filter,PagedQuery pagedQuery)
    {
        IQueryable<Bus> query = context.Buses.AsNoTracking();
        if (filter.Number != null)
        {
            query = query.Where(x=>x.Number==filter.Number);
        }
         if (filter.Capacity>0)
        {
            query = query.Where(x=>x.Capacity==filter.Capacity);
        }
        var total = await  query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var buses = query.ToList();
        var response = new PagedResult<Bus>()
        {
            Items = buses,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
            TotalPages = total/pagedQuery.PageSize
        }; 
        return response;
    }

}