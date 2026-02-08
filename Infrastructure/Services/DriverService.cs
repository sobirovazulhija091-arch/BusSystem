
using Microsoft.EntityFrameworkCore;
using System.Net;
public class DriverService(ApplicationDbcontext dbcontext) : IDriverService
{
    private readonly ApplicationDbcontext context = dbcontext;
    public async Task<Response<string>> AddAsync(DriverDto driver)
    {
        var driver1 = new Driver
        {
            FirstName=driver.FirstName,
            LastName=driver.LastName,
            PhoneNumber=driver.PhoneNumber,
            PaymentType=driver.PaymentType
        };
        await context.Drivers.AddAsync(driver1);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.Created,"Driver Created Successfully");
    }

    public async Task<Response<string>> DeleteAsync(int driverid)
    {
        var del = await context.Drivers.FindAsync(driverid);
        context.Drivers.Remove(del);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }

    public async Task<Response<Driver>> GetDriverByIdAsync(int driverid)
    {
         var driver = await context.Drivers.FirstOrDefaultAsync(d => d.Id == driverid);
    if (driver == null)
    {
        return new Response<Driver>(HttpStatusCode.NotFound,"Driver not found");
    }  
    return new Response<Driver>( HttpStatusCode.OK,"OK",driver);
    }

    public async Task<PagedResult<Driver>> GetDriversAsync(Driverfilter filter,PagedQuery pagedQuery)
    {
          IQueryable<Driver> query = context.Drivers.AsNoTracking();
          if(filter.FirstName!=null!)
        {
            query = query.Where(x=>x.FirstName==filter.FirstName);
        }
          if(filter.PhoneNumber!=null!)
        {
            query = query.Where(x=>x.PhoneNumber==filter.PhoneNumber);
        }
        var total = await  query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var drivers = query.ToList();
        var response = new PagedResult<Driver>()
        {
            Items = drivers,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
            TotalPages = total/pagedQuery.PageSize
        }; 
        return response;
    }

    public async Task<Response<string>> UpdateAsync(int driverid, UpdateDriverDto driver)
    {
        var driv = await context.Drivers.FindAsync(driverid);
        driv.FirstName=driver.FirstName;
        driv.LastName=driver.LastName;
        driv.PaymentType=driver.PaymentType;
        driv.PhoneNumber=driver.PhoneNumber;
       await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Update successfull");
    }
}