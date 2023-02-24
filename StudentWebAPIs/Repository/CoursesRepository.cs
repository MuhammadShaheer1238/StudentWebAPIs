using Microsoft.EntityFrameworkCore;
using StudentWebAPIs.Data;
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        public readonly StudentDbContext _dbContext;
        public CoursesRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }   

        public async Task<bool> AddCourses(Courses courses)
        {
            if(courses != null)
            {
                await _dbContext.AddAsync(courses);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCourses(Guid id)
        {
            var result = await _dbContext.courses.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(result != null)
            {
                _dbContext.courses.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Courses>> GetAllCourses()
        {
            return await _dbContext.courses.ToListAsync();
        }

        public async Task<Courses> GetCoursesById(Guid id)
        {
            var result = await _dbContext.courses.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;

        }

        public async Task<bool> UpdateCourses(Courses courses, Guid id)
        {
            var result =await _dbContext.courses.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(result != null)
            {
                result.CourseName = courses.CourseName;
                result.CourseCode = courses.CourseCode;
                result.InstructorId = courses.InstructorId;

                _dbContext.courses.Update(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
