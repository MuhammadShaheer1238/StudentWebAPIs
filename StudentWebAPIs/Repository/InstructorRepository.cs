using Microsoft.EntityFrameworkCore;
using StudentWebAPIs.Data;
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        public readonly StudentDbContext _dbContext;
        public InstructorRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task<bool> AddInstructor(Instructors instructor)
        {
            if(instructor != null)
            {
                await _dbContext.instructors.AddAsync(instructor);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteInstructor(Guid id)
        {
            var result = await _dbContext.instructors.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(result != null)
            {
                _dbContext.instructors.Remove(result);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<IEnumerable<Instructors>> GetAllInstructors()
        {
            return await _dbContext.instructors.ToListAsync();
        }

        public async Task<Instructors> GetInstructorById(Guid id)
        {
            var result = await _dbContext.instructors.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateInstructor(Instructors instructors, Guid id)
        {
            var result = await _dbContext.instructors.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(result != null)
            {
                result.InstructorName = instructors.InstructorName;
                result.Age = instructors.Age;
                result.PhoneNum = instructors.PhoneNum;
                result.Address = instructors.Address;

                _dbContext.instructors.Update(result);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
