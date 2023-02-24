namespace StudentWebAPIs.Model.Domain
{
    public class Courses
    {
        public Guid Id { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public Guid InstructorId { get; set; }

        ////Navigation property 

        public Instructors? Instructors { get; set; }

        public ICollection<StudentCourses>? studentCourses { get; set; }

    }
}
