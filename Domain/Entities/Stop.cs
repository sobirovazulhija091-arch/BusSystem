public class Stop
{
    public int Id{get;set;}
    public string StopName{get;set;}=null!;
    public string Location{get;set;}=null!;
    public List<Station> Stations{get;set;}=[];
     public List<Schedule> Schedules{get;set;}=[];
}