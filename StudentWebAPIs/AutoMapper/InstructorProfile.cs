using AutoMapper;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;

namespace StudentWebAPIs.AutoMapper
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructors,InstructorDTO>().ReverseMap();
        }
    }
}
