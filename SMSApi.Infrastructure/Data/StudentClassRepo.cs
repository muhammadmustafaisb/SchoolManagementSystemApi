using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;


namespace SMSApi.Infrastructure.Data
{
    public class StudentClassRepo
    {
        private readonly ApplicationDbContext _studentClassDbContext;

        public StudentClassRepo(ApplicationDbContext studentClassDbContext)
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

    }
}
