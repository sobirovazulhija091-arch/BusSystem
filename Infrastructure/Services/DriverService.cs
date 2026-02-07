
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

    public Task<Response<string>> DeleteAsync(int driverid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Driver>> GetDriverByIdAsync(int driverid)
    {
        throw new NotImplementedException();
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

    public Task<Response<string>> UpdateAsync(int driverid, UpdateDriverDto driver)
    {
        throw new NotImplementedException();
    }
}