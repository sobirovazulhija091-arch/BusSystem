
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
        return new Response<string>(HttpStatusCode.OK," Created Successfully");
    }

    public async Task<Response<string>> DeleteAsync(int pathid)
    {
        var del = await context.Paths.FindAsync(pathid);
        context.Paths.Remove(del);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");
    }

    public async Task<Response<Path>> GetPathByIdAsync(int pathid)
    {
       var path = await context.Paths.FirstOrDefaultAsync(p => p.Id == pathid);
    if (path == null)
    {
        return new Response<Path>(HttpStatusCode.NotFound,"Path not found");
    }  
    return new Response<Path>( HttpStatusCode.OK,"OK",path);
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

    public async Task<Response<string>> UpdateAsync(int pathid, UpdatePathDto path)
    {
        var path1 =await context.Paths.FindAsync(pathid);
        path1.EndPoint=path.EndPoint;
        path1.EstimateTime=path.EstimateTime;
        path1.StartingPoint=path.StartingPoint;
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK,"Update successfull");
    }
}