using SMSApi.Core.Models;

namespace SMSApi.Core.Repositories
{
    public interface IStudentRepository
    {
        Task CreateStudentAsync(Student student);
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetAllStudentByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateStudent(Student student);
        Task DeleteStudentAsync(Student student);
    }
}
