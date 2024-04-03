using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Data;

namespace SMSApi.Infrastructure.Data
{
    public class SubjectRepo : ISubjectRepo
    {
        private readonly ApplicationDbContext _subjectDbContext;

        public SubjectRepo(ApplicationDbContext applicationDbContext)
        {
            _subjectDbContext = applicationDbContext;
        }


        public async Task CreateSubjectAsync(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }
            await _subjectDbContext.Subjects.AddAsync(subject);

        }

        public async Task DeleteSubjectAsync(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }
            _subjectDbContext.Subjects.Remove(subject);
            await _subjectDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectAsync()
        {
            return await _subjectDbContext.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _subjectDbContext.Subjects.FirstOrDefaultAsync(p => p.SubId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _subjectDbContext.SaveChangesAsync()) >= 0;
        }

        public void UpdateSubject(Subject subject)
        {

        }

    }
}
