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

        public Task<double> CalculateAverageByCourseAsync(int CourseId, int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<double> CalculateAverageByCourseAsync(int CourseId, List<Course> courses)
        {
            throw new NotImplementedException();
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
            CourseToUpdate.Score = course.Score;
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Course>> GetAllCourseWithCourseId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllCourseWithStudentId(int StudentId)
        {
            return await _unitOfWork.Courses
                    .GetAllWithStudentByStudentIdAsync(StudentId);
        }

        public async Task<IEnumerable<Course>> GetAllWithStudent()
        {
            return await _unitOfWork.Courses
                    .GetAllWithStudentAsync();
        }
    }
}
