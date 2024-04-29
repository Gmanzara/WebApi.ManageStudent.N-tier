using ManageStudent.Core.Models;
using ManageStudent.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStudent.Data.Repositories
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        private readonly  ManageStudentDbContext _dbManageStudentContext;
        public EnrollmentRepository(ManageStudentDbContext dbManageStudentContext) : base(dbManageStudentContext)
        {
            _dbManageStudentContext = dbManageStudentContext;
        }

     
        
    }
}
