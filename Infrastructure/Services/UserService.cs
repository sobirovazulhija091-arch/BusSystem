
using Microsoft.EntityFrameworkCore;
using System.Net;

public class UserService(ApplicationDbcontext dbcontext):IUserService
{
     private readonly ApplicationDbcontext context = dbcontext;

    public async Task<Response<string>> AddAsync(UserDto user)
    {
         var users = new User
         {
             FirstName=user.FirstName,
             LastName=user.LastName,
             PhoneNumber=user.PhoneNumber
         };
           await context.Users.AddAsync(users);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.Created," Created Successfully");
    }

    public async Task<Response<string>> DeleteAsync(int userid)
    {
         var del = await context.Users.FindAsync(userid);
        context.Users.Remove(del);
        await context.SaveChangesAsync();
        if(del==null)
        {
        return new Response<string>(HttpStatusCode.NoContent,"Id not found");
        }
        return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }

    public async Task<Response<User>> GetUserByIdAsync(int userid)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userid);
     if (user == null)
    {
        return new Response<User>(HttpStatusCode.NotFound,"Driver not found");
    }  
    return new Response<User>( HttpStatusCode.OK,"OK",user);
    }

    public async Task<PagedResult<User>> GetUsersAsync(Userfilter filter, PagedQuery pagedQuery)
    {
        IQueryable<User> query = context.Users.AsNoTracking();
        if (filter.FirstName != null)
        {
            query = query.Where(x=>x.FirstName==filter.FirstName);
        }
         if (filter.LastName != null)
        {
            query = query.Where(x=>x.LastName==filter.LastName);
        }
         if (filter.PhoneNumber != null)
        {
            query = query.Where(x=>x.PhoneNumber==filter.PhoneNumber);
        }
        var total = await  query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
         var users = query.ToList();
        var response = new PagedResult<User>()
        {
            Items = users ,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
            TotalPages = total/pagedQuery.PageSize
        }; 
        return response;
    }

    public async Task<Response<string>> UpdateAsync(int userid, UpdateUserDto user)
    {
       var u = await context.Users.FindAsync(userid);
       u.FirstName=user.FirstName;
       u.PhoneNumber=user.PhoneNumber;
       u.LastName=user.LastName;
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Update successfull");
    }
}