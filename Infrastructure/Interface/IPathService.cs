public interface IPathService
{
      Task<Response<string>> AddAsync(PathDto path);
     Task<Response<string>> UpdateAsync(int pathid,UpdatePathDto path);
     Task<Response<string>> DeleteAsync(int pathid);
      Task<Response<Path>> GetPathByIdAsync(int pathid);
     Task<PagedResult<Path>> GetPathsAsync(Pathfilter filter, PagedQuery pagedQuery);
}