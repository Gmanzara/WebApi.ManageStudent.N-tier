using ManageStudent.Core.Models;
using ManageStudent.Core.Repositories;

namespace ManageStudent.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly  ManageStudentDbContext _dbManageStudentContext;
        public StudentRepository(ManageStudentDbContext dbManageStudentContext) : base(dbManageStudentContext)
        {
            _dbManageStudentContext = dbManageStudentContext;
        }
    }
}
