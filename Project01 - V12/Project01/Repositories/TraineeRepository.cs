using Project01.Models;

namespace Project01.Repositories
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly TrCenterContext context;

        public TraineeRepository(TrCenterContext context)
        {
            this.context = context;
        }
        public List<Trainee> GetAll()
        {


            return context.Trainee.ToList();


        }

        public Trainee GetById(int id)
        {

            return context.Trainee.FirstOrDefault(c => c.Id == id);

        }

        public void Insert(Trainee trainee)
        {

            //context.Course.Add(course);
            context.Add(trainee);


        }
        public void Update(Trainee trainee)
        {
            context.Update(trainee);
        }

        public void Delete(Trainee trainee)
        {
            context.Remove(trainee);
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            Delete(course);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
