
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
        return new Response<string>(HttpStatusCode.OK," Created Successfully");
    }

    public async Task<Response<string>> DeleteAsync(int scheduleid)
    {
         var del = await context.Schedules.FindAsync(scheduleid);
        context.Schedules.Remove(del);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }

    public async Task<Response<Schedule>> GetScheduleByIdAsync(int scheduleid)
    {
      var schedule = await context.Schedules.FirstOrDefaultAsync(d => d.Id == scheduleid);
     if (schedule == null)
    {
        return new Response<Schedule>(HttpStatusCode.NotFound,"Driver not found");
    }  
    return new Response<Schedule>( HttpStatusCode.OK,"OK",schedule);
    }

    public async Task<PagedResult<Schedule>> GetSchedulesAsync(Schedulefilter filter, PagedQuery pagedQuery)
    {
        IQueryable<Schedule> query = context.Schedules.AsNoTracking();
        if(filter.ArrivalTime!=null)
        {
            query = query.Where(x=> x.ArrivalTime.Hour == filter.ArrivalTime.Hour &&
                                    x.ArrivalTime.Minute == filter.ArrivalTime.Minute);
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

    public async Task<Response<string>> UpdateAsync(int scheduleid, UpdateScheduleDto schedule)
    {
        var s= await context.Schedules.FindAsync(scheduleid);
        s.BusId=schedule.BusId;
        s.DriverId=schedule.DriverId;
        s.ArrivalTime=schedule.ArrivalTime;
        s.StopId=schedule.StopId;
        s.PathId=schedule.PathId;
       await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Update successfull");
    }
}