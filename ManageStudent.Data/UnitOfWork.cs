using ManageStudent.Core;
using ManageStudent.Core.Repositories;
using ManageStudent.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManageStudentDbContext _dbManageStudentDbContext;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        public UnitOfWork(ManageStudentDbContext dbManageStudentDbContext)
        {
            _dbManageStudentDbContext = dbManageStudentDbContext;
            
        }
        public IStudentRepository Students => _studentRepository ?? new StudentRepository(_dbManageStudentDbContext);
        public ICourseRepository Courses => _courseRepository ?? new CourseRepository(_dbManageStudentDbContext);
        public IUserRepository Users => _userRepository ?? new UserRepository(_dbManageStudentDbContext);

        public async Task<int> CommitAsync()
        {
            return await _dbManageStudentDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbManageStudentDbContext?.Dispose();
        }
    }
}
