using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;
using StudentWebAPIs.Repository;

namespace StudentWebAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentCoursesController : Controller
    {

        public readonly IStudentCoursesRepository _studentCoursesRepository;
        public readonly IMapper _mapper;

        public StudentCoursesController(IStudentCoursesRepository studentCoursesRepository,IMapper mapper)
        {
            this._studentCoursesRepository = studentCoursesRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllStudentCourses")]
        public async Task<IActionResult> GetAllStudentCourses()
        {
            var result = await _studentCoursesRepository.GetAllStudentCourses();
            
            var resultDTO = _mapper.Map<List<StudentCoursesDTO>>(result);

            return Ok(resultDTO);
        }

        [HttpGet]
        [Route("GetStudentCoursesById{id:guid}")]

        public async Task<IActionResult> GetStudentCoursesById(Guid id)
        {
            var result = await _studentCoursesRepository.GetStudentCourseById(id);

            var resultDTO = _mapper.Map<StudentCoursesDTO>(result);

            return Ok(resultDTO);
        }

        [HttpPost]
        [Route("AddStudentCourse")]
        public async Task<IActionResult> AddStudentCourse(AddStudentCoursesRequest addStudentCoursesRequest)
        {
            var addStdCourses = new StudentCourses()
            {
                Id = new Guid(),
                StudentId = addStudentCoursesRequest.StudentId,
                CourseId = addStudentCoursesRequest.CourseId
            };

            return Ok(await _studentCoursesRepository.AddStudentCourse(addStdCourses));            

        }

        [HttpDelete]
        [Route("DeleteStudentCoursesById{id:guid}")]

        public async Task<IActionResult> DeleteStudentCoursesById(Guid id)
        {
            return Ok(await _studentCoursesRepository.DeleteStudentCourse(id));
        }

        [HttpPut]
        [Route("UpdateStudentCourses")]

        public async Task<IActionResult> UpdateStudentCourses(UpdateStudentCoursesRequest updateStudentCoursesRequest,Guid id)
        {
            var updateStdCourses = new StudentCourses()
            {
                Id = id,
                StudentId = updateStudentCoursesRequest.StudentId,
                CourseId = updateStudentCoursesRequest.CourseId
            };

            return Ok(await _studentCoursesRepository.UpdateStudentCourse(updateStdCourses,id));
        }


    }
}
