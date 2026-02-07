public interface IPathServiceRepo
{
      Task<int> AddRepoAsync(Path path);
     Task<bool> UpdateRepoAsync(int pathid,Path path);
     Task<bool> DeleteRepoAsync(int pathid);
      Task<Path> GetPathByIdRepoAsync(int pathid);
     Task <List<Path>> GetPathsRepoAsync();
}