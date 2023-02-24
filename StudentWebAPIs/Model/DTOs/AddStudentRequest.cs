namespace StudentWebAPIs.Model.DTOs
{
    public class AddStudentRequest
    {
        public string? FullName { get; set; }
        public string? GuardianName { get; set; }
        public int Age { get; set; }
        public string? Group { get; set; }
        public long PhoneNum { get; set; }
        public string? Address { get; set; }
    }
}
