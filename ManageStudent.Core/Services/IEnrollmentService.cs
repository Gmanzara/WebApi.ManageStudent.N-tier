using ManageStudent.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Core.Services
{
    public interface IEnrollmentService 
    {
        Task<IEnumerable<Enrollment>> GetAllWithEnrollment();
        Task<Enrollment> GetEnrollmentByIdAsync(int id);
        Task<Enrollment> CreateEnrollment(Enrollment enrollment);
        Task UpdateEnrollment(Enrollment enrollmentToUpdate, Enrollment enrollment);
        Task DeleteEnrollment(Enrollment enrollment);
    }

}
