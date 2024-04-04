using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;
using SMSApi.Infrastructure.Data;

namespace SMSApi.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _studentContext;

        public StudentRepository(ApplicationDbContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task CreateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            await _studentContext.Students.AddAsync(student);
        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _studentContext.Students.ToListAsync();
        }

        public async Task<Student> GetAllStudentByIdAsync(int id)
        {
            return await _studentContext.Students.FirstOrDefaultAsync(p => p.StdId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _studentContext.SaveChangesAsync() >= 0;
        }

        public void UpdateStudent(Student student)
        { }

        public async Task DeleteStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException(nameof(student));
            }

            _studentContext.Students.Remove(student);
            await _studentContext.SaveChangesAsync();
        }

    }
}
