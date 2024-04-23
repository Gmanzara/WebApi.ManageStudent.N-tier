using ManageStudent.Core.Models;
using ManageStudent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<double> CalculateAverageByCourseAsync(int studentId, string courseName)
        {
            //var courses =  await _dbManageStudentDbContext.courses
            //                .Include(s=>s.Students)
            //                .Where(c=>c.CourseName == courseName)
            //                .SingleOrDefaultAsync(s=>s.Id == studentId);
            return 0;
        }
    }
}
