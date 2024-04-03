using SMSApi.Core.Models;

namespace SMSApi.Core.Repositories
{
    public interface ISubjectRepository
    {
        Task CreateSubjectAsync(Subject subject);
        Task<IEnumerable<Subject>> GetAllSubjectAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateSubject(Subject subject);
        Task DeleteSubjectAsync(Subject subject);
    }
}
