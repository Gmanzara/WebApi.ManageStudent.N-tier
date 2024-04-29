using ManageStudent.Core;
using ManageStudent.Core.Models;
using ManageStudent.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Services.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            await _unitOfWork.Enrollments.AddAsync(enrollment);
            await _unitOfWork.CommitAsync();
            return enrollment;
        }

        public async Task DeleteEnrollment(Enrollment enrollment)
        {
            _unitOfWork.Enrollments.Remove(enrollment);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetAllWithEnrollment()
        {
            return await _unitOfWork.Enrollments.GetAllAsync();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await _unitOfWork.Enrollments.GetByIdAsync(id);
        }

        public async Task UpdateEnrollment(Enrollment enrollmentToUpdate, Enrollment enrollment)
        {
            enrollmentToUpdate.Score = enrollment.Score;
            enrollmentToUpdate.StudentId = enrollment.StudentId;
            enrollmentToUpdate.CourseId = enrollment.CourseId;


            await _unitOfWork.CommitAsync();

        }
    }
}
