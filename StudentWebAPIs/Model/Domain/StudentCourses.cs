namespace StudentWebAPIs.Model.Domain
{
    public class StudentCourses
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

        public Guid CourseId { get; set; }
        public Courses? Course { get; set; }

    }
}
