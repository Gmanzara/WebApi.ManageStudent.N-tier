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

        public async Task<IEnumerable<Student>> GetAllStudentWithCourseAsync()
        {
            return await _dbManageStudentContext.students
                   .ToListAsync();
        }
        public async Task<Student> GetAllCourseByIdAsync(int id)
        {
            return await _dbManageStudentContext.students
                   .SingleOrDefaultAsync(c => c.Id == id);
        }
        async Task<IEnumerable<Student>> IStudentRepository.GetAllStudentWithCourseAsync()
        {
            return await _dbManageStudentContext.students
                   .ToListAsync();
        }
        async Task<Student> IStudentRepository.GetAllCourseByIdAsync(int id)
        {
            return await _dbManageStudentContext.students
                   .SingleOrDefaultAsync(c => c.Id == id);
        }
        public Task<IEnumerable<Student>> GetAllWithCourseByCourseIdAsync(int courseId)
        {
            throw new System.NotImplementedException();
        }
    }
}
