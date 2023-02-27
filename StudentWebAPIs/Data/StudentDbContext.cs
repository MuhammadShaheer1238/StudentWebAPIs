using Microsoft.EntityFrameworkCore;
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Courses>()
                .HasOne(b => b.Instructors)
            .WithMany(a => a.Courses)
            .HasForeignKey(b => b.InstructorId);

            //modelBuilder.Entity<StudentCourses>()
            //.HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc=> sc.Student)
                .WithMany(s=> s.studentCourses)
                .HasForeignKey(sc=> sc.StudentId);

            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.studentCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(r => r.Roles)
                .WithMany(ur => ur.userRoles)
                .HasForeignKey(r => r.roleId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.userRoles)
                .HasForeignKey(u => u.userId);

        }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Instructors> instructors { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentCourses> studentCourses { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        
    }
}
