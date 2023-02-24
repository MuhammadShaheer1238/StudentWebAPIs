using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Model.DTOs
{
    public class StudentDTO
    {
        public string? FullName { get; set; }
        public string? GuardianName { get; set; }
        public int Age { get; set; }
        public string? Group { get; set; }
        public long PhoneNum { get; set; }
        public string? Address { get; set; }
        //public Guid CourseId { get; set; }

        ////Navigation property

        //public Courses? Courses { get; set; }
    }
}
