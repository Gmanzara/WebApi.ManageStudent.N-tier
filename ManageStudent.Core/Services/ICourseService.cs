using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Services
{
    public interface ICourseService 
    {
        Task<IEnumerable<Course>> GetAllCourse();
        Task<Course> GetCourseById(int id);
        Task<IEnumerable<Course>> GetAllCourseWithCourseId(int id);
        Task<double> CalculateAverageByCourseAsync(int CourseId,int studentId);
        Task<Course> CreateCourse(Course course);
        Task UpdateCourse(Course CourseToUpdate, Course course);
        Task DeleteCourse(Course course);
    }

}
