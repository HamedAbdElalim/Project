using Microsoft.AspNetCore.Mvc;
using Project01.BLL;
using Project01.Models;
using Project01.Repositories;
using Project01.ViewModels;

namespace Project01.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly ITraineeRepository traineeRepository;
        private readonly ICrsResultRepository crsResultRepository;

        public TraineeController(ICourseRepository courseRepository,ITraineeRepository traineeRepository,ICrsResultRepository crsResultRepository)
        {
            this.courseRepository = courseRepository;
            this.traineeRepository = traineeRepository;
            this.crsResultRepository = crsResultRepository;
        }


        public IActionResult Result(int TraineeID,int CrsId)
        {



            //TraineeBLL traineeBLL = new TraineeBLL();
            //CourseBLL courseBLL = new CourseBLL();
            //CrsResultBLL crsResultBLL = new CrsResultBLL();

            //var traineename = traineeBLL.GetTrainee(TraineeID).Name;
            var traineename= traineeRepository.GetById(TraineeID).Name;
            var coursename = courseRepository.GetById(CrsId).Name;

            var result = crsResultRepository.GetResult(TraineeID);
            //var result = crsResultBLL.GetResult( TraineeID);




            var MinDegree = courseRepository.GetById(CrsId).MinDegree;




            //let data be inside ViewModel
            TraineeCourseResultViewModel resultViewModel = new TraineeCourseResultViewModel()
            {
                TraineeName = traineename,
                CourseName = coursename,
                TraineeGrade = result
            };

            // if degree is less than min degree then put in TraineeCourseResultViewModel status = "Failed" else "Passed" and color = "Red" else "Green"
            if (result < MinDegree)
            {
                resultViewModel.Status = "Failed";
                resultViewModel.Color = "Red";
            }
            else
            {
                resultViewModel.Status = "Passed";
                resultViewModel.Color = "Green";
            }

            //if (result < MinDegree)
            //{

            //}
            //else
            //{

            //}

            return View("Result", resultViewModel);
        }








    }
}
