
using Microsoft.EntityFrameworkCore;
using System.Net;
public class PathService(ApplicationDbcontext dbcontext):IPathService
{
     private readonly ApplicationDbcontext context = dbcontext;

    public  async Task<Response<string>> AddAsync(PathDto path)
    {
         var path1 =  new Path
         {
             StartingPoint=path.StartingPoint,
             EndPoint=path.StartingPoint,
             EstimateTime=path.EstimateTime
         };
          await context.Paths.AddAsync(path1);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.Created," Created Successfully");
    }

    public Task<Response<string>> DeleteAsync(int pathid)
    {
        throw new NotImplementedException();
    }

    public Task<Response<Path>> GetPathByIdAsync(int pathid)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<Path>> GetPathsAsync(Pathfilter filter, PagedQuery pagedQuery)
    {
         IQueryable<Path> query = context.Paths.AsNoTracking();
         if(filter.EndPoint!=null)
        {
            query = query.Where(x=>x.EndPoint==filter.EndPoint);
        }
        if(filter.StartingPoint!=null)
        {
            query = query.Where(x=>x.StartingPoint==filter.StartingPoint);
        }
         var total = await  query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var paths = query.ToList();
        var response = new PagedResult<Path>()
        {
            Items = paths,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
            TotalPages = total/pagedQuery.PageSize
        }; 
        return response;
    }

    public Task<Response<string>> UpdateAsync(int pathid, UpdatePathDto path)
    {
        throw new NotImplementedException();
    }
}