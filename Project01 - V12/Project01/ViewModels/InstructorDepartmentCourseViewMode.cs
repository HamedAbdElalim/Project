using Microsoft.Identity.Client;
using Project01.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project01.ViewModels
{
    public class InstructorDepartmentCourseViewMode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public decimal? Salary { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
       

        public List<Department> DeptList { get; set; }

        public List<Course> CourseList { get; set; }
    }
}
