using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Services
{
    public interface ICourseService 
    {
        Task<IEnumerable<Course>> GetAllCourse();
        Task<Course> GetCourseById(int id);
        Task<Course> CreateCourse(Course course);
        Task UpdateCourse(Course CourseToUpdate, Course course);
        Task DeleteCourse(Course course);
    }

}
