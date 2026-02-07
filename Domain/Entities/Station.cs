public class Station
{
    public string Name{get;set;}=null!;
    public int Id{get;set;}
    public int PathId{get;set;}
    public int StopId{get;set;}
    public Path? Path{get;set;}
    public Stop? Stop{get;set;}

}