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

        public Task<double> CalculateAverageByCourseAsync(int studentId, Course course)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Student> GetAllCoursesByIdAsync(int id)
        {
            return await _dbManageStudentDbContext.students
                    .Include(s => s.Courses)
                    .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Student>> GetAllCourseWithStudentAsync()
        {
             return await _dbManageStudentDbContext.students
                    .Include(s => s.Courses)
                    .ToListAsync();
        }
    }
}
