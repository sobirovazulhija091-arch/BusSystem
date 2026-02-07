public class Path
{
     public int Id{get;set;}
     public  string StartingPoint{get;set;}=null!;
     public string  EndPoint{get;set;}=null!;
     public TimeOnly EstimateTime{get;set;}
      public List<Station> Stations{get;set;}=[];
       public List<Schedule> Schedules{get;set;}=[];
}