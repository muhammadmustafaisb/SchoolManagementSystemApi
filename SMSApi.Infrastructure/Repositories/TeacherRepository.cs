using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;
using SMSApi.Infrastructure.Data;

namespace SMSApi.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _teacherContext;

        public TeacherRepository(ApplicationDbContext teacherContext)
        {
            _teacherContext = teacherContext;
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            await _teacherContext.Teachers.AddAsync(teacher);
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            return await _teacherContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _teacherContext.Teachers.FirstOrDefaultAsync(t => t.TeachId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _teacherContext.SaveChangesAsync() >= 0;
        }

        public void UpdateTeacher(Teacher teacher) { }

        public async Task DeleteTeacherAsync(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            _teacherContext.Teachers.Remove(teacher);
            await _teacherContext.SaveChangesAsync();
        }
    }
}
