using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Model.DTOs
{
    public class AddInstructorRequest
    {
        
        public string? InstructorName { get; set; }
        public int Age { get; set; }
        public string? PhoneNum { get; set; }
        public string? Address { get; set; }

    }
}
