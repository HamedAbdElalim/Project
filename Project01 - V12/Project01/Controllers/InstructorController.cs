using Microsoft.AspNetCore.Mvc;
using Project01.Models;
using Project01.Repositories;
using Project01.ViewModels;

namespace Project01.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IDepartmentRepository departmentRepository;

        public InstructorController( IInstructorRepository instructorRepository,ICourseRepository courseRepository,IDepartmentRepository departmentRepository)
        {
            this.instructorRepository = instructorRepository;
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
        }


        public IActionResult ShowAll(int? page)
        {
            int pageSize = 5; // Number of instructors per page
            int pageNumber = page ?? 1;

            var instructors = instructorRepository.GetAll().AsQueryable();
            var paginatedInstructors = PaginatedList<Instructor>.Create(
                instructors,
                pageNumber,
                pageSize
            );

            return View("ShowAll", paginatedInstructors);
        }


        public IActionResult New()
        {
           List<Department> deptList = departmentRepository.GetAll();
            List<Course> courseList = courseRepository.GetAll();
            InstructorDepartmentCourseViewMode instructorDepartmentCourseViewMode = new InstructorDepartmentCourseViewMode();
           instructorDepartmentCourseViewMode.DeptList = deptList;
            instructorDepartmentCourseViewMode.CourseList = courseList;
            return View("New", instructorDepartmentCourseViewMode);

           
        }



        [HttpPost]
        public IActionResult SaveNew (InstructorDepartmentCourseViewMode instructorDepartmentCourseViewMode)
        {
            

            if (instructorDepartmentCourseViewMode.Name != null)
            {

                Instructor instructor = new Instructor
                {
                    Name = instructorDepartmentCourseViewMode.Name,
                    ImageURL = instructorDepartmentCourseViewMode.ImageURL,
                    Salary = instructorDepartmentCourseViewMode.Salary,
                    Address = instructorDepartmentCourseViewMode.Address,
                    DepartmentId = instructorDepartmentCourseViewMode.DepartmentId,
                    CourseId = instructorDepartmentCourseViewMode.CourseId
                };
                //Context.Instructor.Add(instructor);
                instructorRepository.Insert(instructor);
                instructorRepository.Save();
                //Context.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            instructorDepartmentCourseViewMode.CourseList = courseRepository.GetAll();
            instructorDepartmentCourseViewMode.DeptList = departmentRepository.GetAll();
            return View("New", instructorDepartmentCourseViewMode);


        }




        public IActionResult Search(string search)
        {
            List<Instructor> instructors = instructorRepository.GetAll().Where(s => s.Name.Contains(search)).ToList();
            return View("Search", instructors);
        }







        public IActionResult ShowInstructorsById(int id)
        {
            Instructor Instructor = instructorRepository.GetAll().FirstOrDefault(s => s.Id == id);
            return View("ShowInstructorsById", Instructor);
        }















        //TrCenterContext Context = new TrCenterContext();


        //public IActionResult ShowAll()
        //{

        //    List<Instructor> Instructors = Context.Instructor.ToList();

        //    return View("ShowAll" , Instructors);

        //}

        //public IActionResult ShowInstructorsById(int id) 
        //{
        //   Instructor Instructor= Context.Instructor.FirstOrDefault(s => s.Id == id);

        //    return View("ShowInstructorsById", Instructor);
        //}
    }
}
