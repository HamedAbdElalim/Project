using Microsoft.AspNetCore.Cors.Infrastructure;
using Project01.Models;

namespace Project01.Repositories
{
    public class CrsResultRepository : ICrsResultRepository
    {
        private readonly TrCenterContext context;

        public CrsResultRepository(TrCenterContext context)
        {
            this.context = context;
        }
        public List<CrsResult> GetAll()
        {


            return context.CrsResult.ToList();


        }

        public CrsResult GetById(int id)
        {

            return context.CrsResult.FirstOrDefault(c => c.Id == id);

        }

        public void Insert(CrsResult crsResult)
        {

            //context.Course.Add(course);
            context.Add(crsResult);


        }
        public void Update(CrsResult crsResult)
        {
            context.Update(crsResult);
        }

        public void Delete(CrsResult crsResult)
        {
            context.Remove(crsResult);
        }

        public void Delete(int id)
        {
            var crsResult = GetById(id);
            Delete(crsResult);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        public decimal GetResult(int traineeId)
        {
            var result = context.CrsResult.FirstOrDefault(c => c.TraineeId == traineeId);
            if (result == null)
            {
                return 0;
            }
            return result.Degree.Value;
        }
    }
}
