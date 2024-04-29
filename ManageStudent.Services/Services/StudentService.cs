using ManageStudent.Core;
using ManageStudent.Core.Models;
using ManageStudent.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await _unitOfWork.Students.AddAsync(student);
            await _unitOfWork.CommitAsync();
            return student;
        }

        public async Task DeleteStudent(Student student)
        {
            _unitOfWork.Students.Remove(student);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Student>> GetAllWithStudent()
        {
            return await _unitOfWork.Students.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _unitOfWork.Students.GetByIdAsync(id);
        }
     
        public async Task UpdateStudent(Student studentToUpdate, Student student)
        {
            studentToUpdate.Name = student.Name;
            studentToUpdate.LastName = student.LastName;

            await _unitOfWork.CommitAsync();

        }
    }
}
