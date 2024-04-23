using ManageStudent.Core.Models;
using System.Threading.Tasks;

namespace ManageStudent.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<double> CalculateAverageByCourseAsync(int studentId, string courseName);
    }
}
