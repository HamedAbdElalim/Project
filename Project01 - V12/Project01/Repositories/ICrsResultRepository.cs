using Project01.Models;

namespace Project01.Repositories
{
    public interface ICrsResultRepository : IRepository<CrsResult>
    {
        decimal GetResult(int traineeId);
       
    }
}