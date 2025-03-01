using Microsoft.AspNetCore.Mvc;
using Project01.Models;
using Project01.Repositories;

namespace Project01.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly IDepartmentRepository departmentRepository;

        //TrCenterContext Context = new TrCenterContext();



        public CourseController(ICourseRepository courseRepository,IDepartmentRepository departmentRepository)
        {
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
        }
        public IActionResult ShowAll(int? page,string SearchName)
        {

            int pageSize = 5; // Number of instructors per page
            int pageNumber = page ?? 1;
            PaginatedList<Course> paginatedCourses;
            if (!string.IsNullOrEmpty(SearchName))
            {
                
                var SearchedCourses = courseRepository.GetAll().Where(c => c.Name.Contains(SearchName)).AsQueryable();
                 paginatedCourses = PaginatedList<Course>.Create(
                SearchedCourses,
                pageNumber,
                pageSize
            );
                return View("ShowAll", paginatedCourses);
            }
           

            var courses = courseRepository.GetAll().AsQueryable();
             paginatedCourses = PaginatedList<Course>.Create(
                courses,
                pageNumber,
                pageSize
            );

            return View("ShowAll", paginatedCourses);
         
        }




        public IActionResult New()
        {
            ViewBag.deptList = departmentRepository.GetAll();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Course courseFromRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                //Context.Course.Add(courseFromRequest);
                    courseRepository.Insert(courseFromRequest);
                    courseRepository.Save();
                //Context.SaveChanges();
                return RedirectToAction("ShowAll");
                }
                catch(Exception ex)
                {

                    //ModelState.AddModelError("DepartmentId", ex.Message);
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            ViewBag.deptList = departmentRepository.GetAll();

            return View("New", courseFromRequest);


            //if (ModelState.IsValid)
            //{
            //    Context.Course.Add(course);
            //    Context.SaveChanges();
            //    return RedirectToAction("ShowAll");
            //}
            //return View("New");
        }


        public IActionResult IsCourseNameExist(int Hours)
        {
           
            if ( Hours % 3 == 0  )
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult IsminHours (int MinDegree,int Degree)
        {
            if (MinDegree > Degree)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
    }
}
