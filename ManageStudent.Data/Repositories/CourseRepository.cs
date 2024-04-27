using ManageStudent.Core.Models;
using ManageStudent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStudent.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ManageStudentDbContext _dbManageStudentDbContext;
        public CourseRepository(ManageStudentDbContext dbManageStudentDbContext) : base(dbManageStudentDbContext)
        {
            _dbManageStudentDbContext = dbManageStudentDbContext;
        }

        public async Task<IEnumerable<Course>> GetAllWithStudentAsync()
        {
            return await _dbManageStudentDbContext.courses
                   .ToListAsync();
        }

        public async Task<Course> GetWithStudentByIdAsync(int id)
        {
            return await _dbManageStudentDbContext.courses
                    .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Course>> GetAllWithStudentByStudentIdAsync(int studentId)
        {
            return await _dbManageStudentDbContext.courses
                   .ToListAsync();
        }
        async Task<IEnumerable<Course>> ICourseRepository.GetAllWithStudentAsync()
        {
            return await _dbManageStudentDbContext.courses
                .ToListAsync();
        }

        async Task<Course> ICourseRepository.GetWithStudentByIdAsync(int id)
        {
            return await _dbManageStudentDbContext.courses
                    .SingleOrDefaultAsync(c => c.Id == id);
        }

        async Task<IEnumerable<Course>> ICourseRepository.GetAllWithStudentByStudentIdAsync(int studentId)
        {
            return await _dbManageStudentDbContext.courses
                   .ToListAsync();
        }

        public async Task<double> CalculateAverageByCourseAsync(int studentId, List<Course> courses)
        {
            var coursesStudentId = GetAllWithStudentByStudentIdAsync(studentId);
            return 0;
        }

    }
}
