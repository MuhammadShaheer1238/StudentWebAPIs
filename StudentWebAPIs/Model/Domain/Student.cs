namespace StudentWebAPIs.Model.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? GuardianName { get; set; }
        public int Age { get; set; }
        public string? Group { get; set; }
        public long PhoneNum { get; set; }
        public string? Address { get; set; }

        //navigation property
        public ICollection<StudentCourses>? studentCourses { get; set; }


    }
}
