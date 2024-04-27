using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetAllWithStudentAsync();
        Task<Course> GetWithStudentByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllWithStudentByStudentIdAsync(int studentId);
        Task<double> CalculateAverageByCourseAsync(int studentId,List<Course> courses);
    }
}
