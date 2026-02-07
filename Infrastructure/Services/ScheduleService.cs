
using Microsoft.EntityFrameworkCore;
using System.Net;
public class ScheduleService(ApplicationDbcontext dbcontext):IScheduleService
{
     private readonly ApplicationDbcontext context = dbcontext;

    public async Task<Response<string>> AddAsync(ScheduleDto schedule)
    {
       var sch = new Schedule
       {
            BusId=schedule.BusId,
   DriverId=schedule.DriverId,
    StopId=schedule.StopId,
    PathId=schedule.PathId,
   ArrivalTime=schedule.ArrivalTime
       };   
        await context.Schedules.AddAsync(sch);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.Created," Created Successfully");
    }

    public Task<Response<string>> DeleteAsync(int scheduleid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Schedule>> GetScheduleByIdAsync(int scheduleid)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<Schedule>> GetSchedulesAsync(Schedulefilter filter, PagedQuery pagedQuery)
    {
        IQueryable<Schedule> query = context.Schedules.AsNoTracking();
        if(filter.ArrivalTime>0)
        {
            query = query.Where(x=>x.ArrivalTime==filter.ArrivalTime);
        }
         var total = await  query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var schedules = query.ToList();
        var response = new PagedResult<Schedule>()
        {
            Items = schedules,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
            TotalPages = total/pagedQuery.PageSize
        }; 
        return response;
    }

    public Task<Response<string>> UpdateAsync(int scheduleid, UpdateScheduleDto schedule)
    {
        throw new NotImplementedException();
    }
}