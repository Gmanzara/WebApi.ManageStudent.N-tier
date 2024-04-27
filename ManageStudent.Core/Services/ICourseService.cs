using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Services
{
    public interface ICourseService 
    {
        Task<IEnumerable<Course>> GetAllCourse();
        Task<IEnumerable<Course>> GetAllWithStudent();
        Task<Course> GetCourseById(int id);
        Task<IEnumerable<Course>> GetAllCourseWithStudentId(int StudentId);
        Task<double> CalculateAverageByCourseAsync(int CourseId,List<Course> courses);
        Task<Course> CreateCourse(Course course);
        Task UpdateCourse(Course CourseToUpdate, Course course);
        Task DeleteCourse(Course course);
    }

}
