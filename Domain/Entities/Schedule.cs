public class Schedule
{
  public int Id{get;set;}
  public int BusId{get;set;}
  public int DriverId{get;set;}
  public int StopId{get;set;}
  public int PathId{get;set;}
  public TimeOnly ArrivalTime{get;set;}
  public Bus? Bus{get;set;}
  public Driver? Driver{get;set;}
  public Stop? Stop{get;set;}
  public Path? Path{get;set;}
}