namespace StudentWebAPIs.Model.Domain
{
    public class Roles
    {
        public Guid Id { get; set; }
        public string? roleName { get; set; }

        //navigation property

        public ICollection<UserRoles>? userRoles { get; set; }
    }
}
