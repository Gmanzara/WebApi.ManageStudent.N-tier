using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Student>> GetAllCourseWithStudentAsync();
        Task<Student> GetAllCoursesByIdAsync(int id);
        Task<double> CalculateAverageByCourseAsync(int studentId,int courseId);
    }
}
