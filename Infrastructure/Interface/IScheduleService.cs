public interface IScheduleService
{
    
     Task<Response<string>> AddAsync(ScheduleDto schedule);
    Task<Response<string>> UpdateAsync(int scheduleid,UpdateScheduleDto schedule);
     Task<Response<string>> DeleteAsync(int scheduleid);
      Task<Response<Schedule>> GetScheduleByIdAsync(int scheduleid);
    Task<PagedResult<Schedule>> GetSchedulesAsync(Schedulefilter filter,PagedQuery pagedQuery);
}