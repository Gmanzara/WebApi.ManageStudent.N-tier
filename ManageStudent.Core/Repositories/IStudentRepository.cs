using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllStudentWithCourseAsync();
        Task<Student> GetAllCourseByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllWithCourseByCourseIdAsync(int courseId);
    }
}
