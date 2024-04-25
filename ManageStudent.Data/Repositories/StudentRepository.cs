using ManageStudent.Core.Models;
using ManageStudent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStudent.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly  ManageStudentDbContext _dbManageStudentContext;
        public StudentRepository(ManageStudentDbContext dbManageStudentContext) : base(dbManageStudentContext)
        {
            _dbManageStudentContext = dbManageStudentContext;
        }

        public async Task<Student> GetAllCourseByIdAsync(int id)
        {
            return await _dbManageStudentContext.students
                .Include(c => c.Course)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Student>> GetAllStudentWithCourse()
        {
            return await _dbManageStudentContext.students
                .Include(m=>m.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllWithCourseByCourseId(int courseId)
        {
            return await _dbManageStudentContext.students
                .Include(c => c.Course)
                .Where(c => c.CourseId == courseId)
                .ToListAsync();
        }
        async Task<Student> IStudentRepository.GetAllCourseByIdAsync(int id)
        {
            return await _dbManageStudentContext.students
                .Include(c => c.Course)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        async Task<IEnumerable<Student>> IStudentRepository.GetAllStudentWithCourseAsync()
        {
            return await _dbManageStudentContext.students
                .Include(m => m.Course)
                .ToListAsync();
        }

        async Task<IEnumerable<Student>> IStudentRepository.GetAllWithCourseByCourseIdAsync(int courseId)
        {
            return await _dbManageStudentContext.students
                .Include(c => c.Course)
                .Where(c => c.CourseId == courseId)
                .ToListAsync();
        }
    }
}
