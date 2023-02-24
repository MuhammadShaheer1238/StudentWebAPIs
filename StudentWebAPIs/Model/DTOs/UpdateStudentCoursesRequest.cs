namespace StudentWebAPIs.Model.DTOs
{
    public class UpdateStudentCoursesRequest
    {
        public Guid StudentId { get; set; }   
        public Guid CourseId { get; set; }
        
    }
}
