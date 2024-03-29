using SMSApi.Core.Models;

namespace SMSApi.Infrastructure.Data
{
    public class TeacherRepo
    {
        private readonly ApplicationDbContext _teacherContext;

        public TeacherRepo(ApplicationDbContext teacherContext)
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

    }
}
