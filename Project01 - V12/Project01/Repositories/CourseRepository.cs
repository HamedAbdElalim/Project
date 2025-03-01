using Project01.Models;

namespace Project01.Repositories
{
    public class CourseRepository : ICourseRepository
    {

        //TrCenterContext context = new TrCenterContext();

        private readonly TrCenterContext context;
        public CourseRepository(TrCenterContext context)
        {
            this.context = context;
        }
        public List<Course> GetAll()
        {

          
                return context.Course.ToList();
            

        }

        public Course GetById(int id)
        {
          
                return context.Course.FirstOrDefault(c => c.Id == id);
           
        }

        public void Insert(Course course)
        {
           
                //context.Course.Add(course);
                context.Add(course);


        }
        public void Update(Course course)
        {
            context.Update(course);
        }

        public void Delete(Course course)
        {
            context.Remove(course);
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
