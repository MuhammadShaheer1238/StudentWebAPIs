namespace StudentWebAPIs.Model.Domain
{
    public class UserRoles
    {
        public int Id { get; set; }

        public Guid userId { get; set; }
        public User User { get; set; }

        public Guid roleId { get; set; }
        public Roles Roles { get; set; }
    }
}
