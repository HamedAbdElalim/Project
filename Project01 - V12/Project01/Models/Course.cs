using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Project01.Models.ValidationAttribute;

namespace Project01.Models
{
    public class Course
    {
        public int Id { get; set; }


        [Display(Name = "Course Name")]
        //[Unique]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Name Must Begin With Capital Letter !!")]

        [MinLength(3, ErrorMessage = "Name Must Be More Than 3 Characters")]
        [MaxLength(20, ErrorMessage = "Name Must Be Less Than 20 Characters")]
        public string Name { get; set; }

        
        [Range(50, 100, ErrorMessage = "Degree should be between 50 and 100 !!")]
       
        public decimal? Degree { get; set; }
        [Remote("IsminHours","Course",AdditionalFields ="Degree",ErrorMessage ="min degree must be larger than Degree !!")]
        public decimal? MinDegree { get; set; }

        //[Remote(action: "IsCourseNameExist", controller: "Courses", AdditionalFields = "Id")]
        [Remote("IsCourseNameExist","Course",ErrorMessage = "Hours should be divisble by 3 !! !!")]
        //[Range(1, 30, ErrorMessage = "Max Hours Must Be Minimum Than 30 hours ")]
        public int? Hours { get; set; }


       [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

          
        public ICollection<CrsResult>? CrsResults { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
    }
}
