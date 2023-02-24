using AutoMapper;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;

namespace StudentWebAPIs.AutoMapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
                     .ReverseMap();
        }
    }
}
