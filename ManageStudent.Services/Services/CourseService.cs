using ManageStudent.Core;
using ManageStudent.Core.Models;
using ManageStudent.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageStudent.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async Task<Course> CreateCourse(Course course)
        {
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CommitAsync();
            return course;
        }

        public Task DeleteCourse(Course course)
        {
            _unitOfWork.Courses.Remove(course);
            return _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Course>> GetAllCourse()
        {
            return _unitOfWork.Courses.GetAllAsync();
        }
        public async Task<Course> GetCourseById(int id)
        {
           return await _unitOfWork.Courses.GetByIdAsync(id);
        }

        public async Task UpdateCourse(Course CourseToUpdate, Course course)
        {
            CourseToUpdate.CourseName = course.CourseName;
            await _unitOfWork.CommitAsync();
        }

    }
}
