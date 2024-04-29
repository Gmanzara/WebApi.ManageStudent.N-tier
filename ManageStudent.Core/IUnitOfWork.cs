using ManageStudent.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace ManageStudent.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        IEnrollmentRepository Enrollments { get; }
        IUserRepository Users { get; }
        Task<int > CommitAsync();
    }
}
