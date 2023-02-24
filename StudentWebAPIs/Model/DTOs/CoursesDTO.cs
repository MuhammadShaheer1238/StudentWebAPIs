using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Model.DTOs
{
    public class CoursesDTO
    {
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public Guid InstructorId { get; set; }

    }
}
