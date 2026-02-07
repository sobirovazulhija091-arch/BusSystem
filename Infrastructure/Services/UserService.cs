
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

    public Task<Response<string>> DeleteAsync(int userid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<User>> GetUserByIdAsync(int userid)
    {
        throw new NotImplementedException();
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

    public Task<Response<string>> UpdateAsync(int userid, UpdateUserDto user)
    {
        throw new NotImplementedException();
    }
}