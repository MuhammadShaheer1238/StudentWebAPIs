using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;
using StudentWebAPIs.Repository;

namespace StudentWebAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class InstructorController : Controller
    {
        public readonly IInstructorRepository _instructorRepository;
        public readonly IMapper _mapper;
        public InstructorController(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [Route("GetAllInstructors")]
        public async Task<IActionResult> GetAllInstructors()
        {
            var result = await _instructorRepository.GetAllInstructors();

            var InstructorList = _mapper.Map<List<InstructorDTO>>(result);
            return Ok(InstructorList);
        }

        [HttpGet]
        [Route("GetInstructorById{id:guid}")]

        public async Task<IActionResult> GetInstructorById(Guid id)
        {
            var result = await _instructorRepository.GetInstructorById(id);

            var instructorList = _mapper.Map<InstructorDTO>(result);

            return Ok(instructorList);
        }

        [HttpPost]
        [Route("AddInstructors")]

        public async Task<IActionResult> AddInstructors(AddInstructorRequest instructorsRequest)
        {
            var Instructor = new Instructors()
            {
                Id = new Guid(),
                InstructorName = instructorsRequest.InstructorName,
                Age = instructorsRequest.Age,
                PhoneNum = instructorsRequest.PhoneNum,
                Address = instructorsRequest.Address,
            };

            return Ok(await _instructorRepository.AddInstructor(Instructor));
        }

        [HttpPut]
        [Route("UpdateInstructor")]
        public async Task<IActionResult> UpdateInstructor(UpdateInstructorRequest updateInstructorRequest,Guid id)
        {
            var Instructor = new Instructors()
            {
                Id = id,
                InstructorName = updateInstructorRequest.InstructorName,
                Age = updateInstructorRequest.Age,
                PhoneNum = updateInstructorRequest.PhoneNum,
                Address = updateInstructorRequest.Address
            };

            return Ok(await _instructorRepository.UpdateInstructor(Instructor,id));
        }

        [HttpDelete]
        [Route("DeleteInstructorById{id:guid}")]
        public async Task<IActionResult> DeleteInstructorById(Guid id)
        {
            return Ok(await _instructorRepository.DeleteInstructor(id));
        }
    }
}
