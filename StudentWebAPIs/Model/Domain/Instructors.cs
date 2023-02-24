namespace StudentWebAPIs.Model.Domain
{
    public class Instructors
    {
        public Guid Id { get; set; }
        public string? InstructorName { get; set; }
        public int Age { get; set; }
        public string? PhoneNum { get; set; }
        public string? Address { get; set; }

        //navigation property

        public List<Courses>? Courses { get; set; }

    }
}
