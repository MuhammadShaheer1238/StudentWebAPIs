using AutoMapper;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;

namespace StudentWebAPIs.AutoMapper
{
    public class StudentCoursesProfile : Profile
    {
        public StudentCoursesProfile()
        {
            CreateMap<StudentCourses, StudentCoursesDTO>().ReverseMap();
        }
    }
}
