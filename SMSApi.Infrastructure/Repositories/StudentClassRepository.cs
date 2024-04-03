using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;
using SMSApi.Infrastructure.Data;

namespace SMSApi.Infrastructure.Repositories
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private readonly ApplicationDbContext _studentClassDbContext;

        public StudentClassRepository(ApplicationDbContext studentClassDbContext)
        {
            _studentClassDbContext = studentClassDbContext;
        }

        public async Task CreateStudentClassAsync(StudentClass stdClass)
        {
            if (stdClass == null)
            {
                throw new ArgumentNullException(nameof(stdClass));
            }
            await _studentClassDbContext.StudentClasses.AddAsync(stdClass);
        }

        public async Task<IEnumerable<StudentClass>> GetAllStudentClassAsync()
        {
            return await _studentClassDbContext.StudentClasses.ToListAsync();
        }

        public async Task<StudentClass> GetStudentClassByIdAsync(int id)
        {
            return await _studentClassDbContext.StudentClasses.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _studentClassDbContext.SaveChangesAsync() >= 0;
        }

        public void UpdateStudentClass(StudentClass stdClass)
        {

        }

        public async Task DeleteStudentClassAsync(StudentClass stdClass)
        {
            if (stdClass == null)
            {
                throw new ArgumentNullException(nameof(stdClass));
            }
            _studentClassDbContext.StudentClasses.Remove(stdClass);
            await _studentClassDbContext.SaveChangesAsync();
        }

    }
}
