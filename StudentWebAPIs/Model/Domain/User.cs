using System.ComponentModel.DataAnnotations.Schema;

namespace StudentWebAPIs.Model.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? userName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }

        [NotMapped]
        public List<string>? Roles { get; set; }

        //navigation property
        public ICollection<UserRoles>? userRoles { get; set; }
    }
}
