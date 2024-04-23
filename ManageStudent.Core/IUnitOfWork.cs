using ManageStudent.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace ManageStudent.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        Task<int > CommitAsync();
    }
}
