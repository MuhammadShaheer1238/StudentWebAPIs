using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebAPIs.Data;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;
using StudentWebAPIs.Repository;

namespace StudentWebAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        public readonly IMapper _mapper;
        public readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            //getting data from repository layer
            var students = await _studentRepository.GetAllStudent();

            // return DTOs without using automapper
            //var studentList = new List<StudentDTO>();
            //foreach (var student in students)
            //{
            //    var studentDto = new StudentDTO()
            //    {
                    
            //        FullName = student.FullName,
            //        GuardianName = student.GuardianName,
            //        Age = student.Age,
            //        PhoneNum = student.PhoneNum,
            //        Group = student.Group,
            //        Address = student.Address
            //    };
            //    studentList.Add(studentDto);
            //}

            //using auto mapper
            var studentList = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentList);
        }

        [HttpGet]
        [Route("GetStudentById{id:guid}")]

        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if(student == null)
            {
                NotFound();
            }

            var studentListDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentListDTO);
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent(AddStudentRequest addStudent)
        {
            //getting data from DTO and bind it to the Domain Model
            var student = new Student()
            {
                Id = new Guid(),
                FullName = addStudent.FullName,
                GuardianName = addStudent.GuardianName,
                Age = addStudent.Age,
                Group = addStudent.Group,
                Address=addStudent.Address,
                PhoneNum=addStudent.PhoneNum
            };

            //send domain model to service layer
            return Ok(await _studentRepository.AddStudent(student));
            
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(UpdateStudentRequest updateStudentRequest, Guid id)
        {
            //transfering data from DTO to Domain

            var updateStd = new Student()
            {
                Id = id,
                FullName = updateStudentRequest.FullName,
                GuardianName = updateStudentRequest.GuardianName,
                Age = updateStudentRequest.Age,
                Group=updateStudentRequest.Group,
                PhoneNum = updateStudentRequest.PhoneNum,
                Address=updateStudentRequest.Address
            };

            //sending domain data to repository layer

            return Ok(await _studentRepository.UpdateStudent(updateStd,id));

        }

        [HttpDelete]
        [Route("DeleteStudenById{id:guid}")]

        public async Task<IActionResult> DeleteStudenById(Guid id)
        {
           return Ok(await _studentRepository.DeleteStudent(id));
        }


    }
}
