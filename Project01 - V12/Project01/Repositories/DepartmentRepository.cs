using Project01.Models;

namespace Project01.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TrCenterContext context;

     
        public DepartmentRepository(TrCenterContext context)
        {
            this.context = context;
        }
        public List<Department> GetAll()
        {


            return context.Department.ToList();


        }

        public Department GetById(int id)
        {

            return context.Department.FirstOrDefault(c => c.Id == id);

        }

        public void Insert(Department department)
        {

            //context.Course.Add(course);
            context.Add(department);


        }
        public void Update(Department department)
        {
            context.Update(department);
        }

        public void Delete(Department department)
        {
            context.Remove(department);
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            Delete(department);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
