using Project01.Models;

namespace Project01.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly TrCenterContext context;

        public InstructorRepository(TrCenterContext context)
        {
            this.context = context;
        }
        public List<Instructor> GetAll()
        {


            return context.Instructor.ToList();


        }

        public Instructor GetById(int id)
        {

            return context.Instructor.FirstOrDefault(c => c.Id == id);

        }

        public void Insert(Instructor instructor)
        {

            //context.Course.Add(course);
            context.Add(instructor);


        }
        public void Update(Instructor instructor)
        {
            context.Update(instructor);
        }

        public void Delete(Instructor instructor)
        {
            context.Remove(instructor);
        }

        public void Delete(int id)
        {
            var instructor = GetById(id);
            Delete(instructor);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
