using Microsoft.EntityFrameworkCore;
using StudentWebAPIs.Data;
using StudentWebAPIs.Model.Domain;

namespace StudentWebAPIs.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public readonly StudentDbContext _dbContext;
        public StudentRepository(StudentDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        

        public async Task<bool> AddStudent(Student student)
        {
            if(student != null)
            {
                await _dbContext.students.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteStudent(Guid Id)
        {
            var id = await _dbContext.students.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(id != null)
            {
                _dbContext.students.Remove(id);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
                
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _dbContext.students.ToListAsync();
        }

        public async Task<Student> GetStudentById(Guid Id)
        {
            var id = await _dbContext.students.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return id;
        }

        public async Task<bool> UpdateStudent(Student student, Guid Id)
        {
            var existingStd = await _dbContext.students.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if(existingStd != null)
            {
                existingStd.FullName = student.FullName;
                existingStd.GuardianName = student.GuardianName;
                existingStd.Age = student.Age;
                existingStd.PhoneNum = student.PhoneNum;
                existingStd.Group = student.Group;
                existingStd.Address = student.Address;

                _dbContext.students.Update(existingStd);
                await _dbContext.SaveChangesAsync();
                return true;

            }

            return false;
        }
    }
}
