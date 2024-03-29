using SMSApi.Core.Models;

namespace SMSApi.Core.Repositories.Data
{
    public interface IStudentRepo
    {
        Task CreateStudentAsync(Student student);
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetAllStudentByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateStudent(Student student);
        Task DeleteStudentAsync(Student student);
    }
}
