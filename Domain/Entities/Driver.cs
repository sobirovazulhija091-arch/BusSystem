public class Driver
{
    public int Id{get;set;}
    public string FirstName{get;set;}=null!;
    public string LastName{get;set;}=null!;
    public string PhoneNumber{get;set;}=null!;
    public EnumPayment PaymentType{get;set;}
     public List<Schedule> Schedules{get;set;}=[];
}