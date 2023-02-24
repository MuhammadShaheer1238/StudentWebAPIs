namespace StudentWebAPIs.Model.DTOs
{
    public class AddStudentCoursesRequest
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
