public class UpdatePathDto
{
     public int Id{get;set;}
     public  string StartingPoint{get;set;}=null!;
     public string  EndPoint{get;set;}=null!;
     public TimeOnly EstimateTime{get;set;}
}