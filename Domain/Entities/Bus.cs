public class Bus
{
    public int Id{get;set;}
    public string Number{get;set;}=null!;
    public EnumBusType BusType{get;set;} 
    //number max people in the bus
    public  int Capacity{get;set;}
    //number much people are in the  bus now
    public  int CurrentOccupancy{get;set;}
    public int Price{get;set;}
     public List<Schedule> Schedules{get;set;}=[];
}