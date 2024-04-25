using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Services
{
    public interface IStudentService 
    {
        Task<IEnumerable<Student>> GetAllStudentWithCourse();
        Task<Student> GetAllCourseByIdAsync(int id);
        Task<Student> CreateStudent(Student student);
        Task UpdateStudent(Student studentToUpdate, Student student);
        Task DeleteStudent(Student student);
    }

}
