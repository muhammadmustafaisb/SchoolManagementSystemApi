using SMSApi.Core.Models;

namespace SMSApi.Core.Repositories
{
    public interface ITeacherRepository
    {
        Task CreateTeacherAsync(Teacher teacher);
        Task<IEnumerable<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateTeacher(Teacher teacher);
        Task DeleteTeacherAsync(Teacher teacher);
    }
}
