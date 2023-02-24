using AutoMapper;
using StudentWebAPIs.Model.Domain;
using StudentWebAPIs.Model.DTOs;

namespace StudentWebAPIs.AutoMapper
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Courses, CoursesDTO>().ReverseMap();
        }
    }
}
