public interface IScheduleServiceRepo
{
    
     Task<int> AddRepoAsync(Schedule schedule);
     Task<bool> UpdateRepoAsync(int scheduleid,Schedule schedule);
     Task<bool> DeleteRepoAsync(int scheduleid);
    Task<Schedule> GetScheduleByIdRepoAsync(int scheduleid);
    Task<List<Schedule>> GetSchedulesRepoAsync();
}