using SMSApi.Core.Models;

namespace SMSApi.Core.Repositories
{
    public interface IStudentClassRepository
    {
        Task CreateStudentClassAsync(StudentClass stdClass);
        Task<IEnumerable<StudentClass>> GetAllStudentClassAsync();
        Task<StudentClass> GetStudentClassByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateStudentClass(StudentClass stdClass);
        Task DeleteStudentClassAsync(StudentClass stdClass);
    }
}
