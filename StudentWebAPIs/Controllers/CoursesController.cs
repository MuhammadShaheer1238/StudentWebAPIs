using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;
using StudentWebAPIs.Repository;

namespace StudentWebAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        public readonly ICoursesRepository _coursesRepository;
        public readonly IMapper _mapper;
        public CoursesController(ICoursesRepository coursesRepository,IMapper mapper)
        {
            this._coursesRepository = coursesRepository;
            this._mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses =await _coursesRepository.GetAllCourses();

            var coursesList = _mapper.Map<List<CoursesDTO>>(courses);
            return Ok(coursesList);

        }

        [HttpGet]
        [Route("GetCoursesById{id:guid}")]

        public async Task<IActionResult> GetCoursesById(Guid id)
        {
            var result = await _coursesRepository.GetCoursesById(id);

            if (result == null)
            {
                NotFound();
            }
            var courseList =  _mapper.Map<CoursesDTO>(result);

            return Ok(courseList);
        }

        [HttpDelete]
        [Route("DeleteCourseById{id:guid}")]

        public async Task<IActionResult> DeleteCourseById(Guid id)
        {
            return Ok(await _coursesRepository.DeleteCourses(id));
        }

        [HttpPost]
        [Route("AddCourse")]

        public async Task<IActionResult> AddCourse(AddCoursesRequest addCoursesRequest)
        {
            if (!ValidateAddCourseRequest(addCoursesRequest))
            {
                return BadRequest(ModelState);
            }

            //transfering the data from DTO to domain

            var courses = new Courses()
            {
                Id = new Guid(),
                CourseCode = addCoursesRequest.CourseCode,
                CourseName = addCoursesRequest.CourseName,
                InstructorId = addCoursesRequest.InstructorId
            };

          
            return Ok( await _coursesRepository.AddCourses(courses));

        }

        [HttpPut]
        [Route("UpdateCourse")]

        public async Task<IActionResult> UpdateCourse(UpdateCoursesRequest updateCoursesRequest, Guid id)
        {
            if (!ValidateUpdateCourseRequest(updateCoursesRequest))
            {
                return BadRequest(ModelState);
            }

            //transfering the data from DTO to domain

            var courses = new Courses()
            {
                Id = id,
                CourseCode = updateCoursesRequest.CourseCode,
                CourseName = updateCoursesRequest.CourseName,
            };


            return Ok(await _coursesRepository.UpdateCourses(courses,id));
        }

        #region Validation methods

        private bool ValidateAddCourseRequest(AddCoursesRequest addCoursesRequest)
        {
            if(addCoursesRequest == null)
            {
                ModelState.AddModelError(nameof(addCoursesRequest), "Add Courses Request can not be null ");
                return false;
            }
            if(string.IsNullOrEmpty(addCoursesRequest.CourseName))
            {
                ModelState.AddModelError(nameof(addCoursesRequest.CourseName), $"{nameof(addCoursesRequest.CourseName)} Can't be null or empty");
            }
            if(ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }

        private bool ValidateUpdateCourseRequest(UpdateCoursesRequest updateCoursesRequest)
        {
            if (updateCoursesRequest == null)
            {
                ModelState.AddModelError(nameof(updateCoursesRequest), "Add Courses Request can not be null ");
                return false;
            }
            if (string.IsNullOrEmpty(updateCoursesRequest.CourseName))
            {
                ModelState.AddModelError(nameof(updateCoursesRequest.CourseName), $"{nameof(updateCoursesRequest.CourseName)} Can't be null or empty");
            }
            if (string.IsNullOrEmpty(updateCoursesRequest.CourseCode))
            {
                ModelState.AddModelError(nameof(updateCoursesRequest.CourseCode), $"{nameof(updateCoursesRequest.CourseCode)} Can't be null or empty");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }


        #endregion


    }
}
