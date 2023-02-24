using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Model.DTOs
{
    public class UpdateCoursesRequest
    {
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public Guid InstructorId { get; set; }

        ////Navigation property 

        public Instructors? Instructors { get; set; }
    }
}
