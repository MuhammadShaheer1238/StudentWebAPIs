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
        }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Instructors> instructors { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentCourses> studentCourses { get; set; }
        
    }
}
