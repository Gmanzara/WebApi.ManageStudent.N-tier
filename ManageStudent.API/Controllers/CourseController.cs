using AutoMapper;
using FluentValidation;
using ManageStudent.API.Ressources;
using ManageStudent.API.Validation;
using ManageStudent.Core.Models;
using ManageStudent.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStudent.API.Controllers
{
    [Route("api/[controller]", Name="Course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapperServie;
        public CourseController(ICourseService courseService,IMapper mapperServie)
        {
            _courseService = courseService;
            _mapperServie = mapperServie;
        }
        //[SwaggerOperation("GetCourseList")]
        [HttpGet("/api/courses/", Name ="GetCourseList")]
        public async Task<ActionResult<IEnumerable<CourseRessource>>> GetAllCourse()
        {
            try
            {
                var course = await _courseService.GetAllCourse();
                var courseRessources = _mapperServie.Map<IEnumerable<Course>, IEnumerable<CourseRessource>>(course);
                return Ok(courseRessources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CourseRessource>>> GetCourseById(int id) 
        {
            try
            {
               var course =  await _courseService.GetCourseById(id);
                if (course == null) return NotFound();
                var courseRessource = _mapperServie.Map<Course, CourseRessource>(course);
                return Ok(courseRessource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<CourseRessource>> CreateCourse(SaveCourseRessource saveCourseRessource)
        {
            //Validation
            var validation = new SaveCourseRessourceValidator();

            var validationResult =  await validation.ValidateAsync(saveCourseRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Mappage
            var course = _mapperServie.Map<SaveCourseRessource, Course>(saveCourseRessource);
            //Create de couurse
            var newCourse = await _courseService.CreateCourse(course);
            //Mappage
            var musicRessource = _mapperServie.Map<Course, CourseRessource>(newCourse);
            return Ok(musicRessource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseRessource>> UpdateCreate(int id,SaveCourseRessource saveCourseRessource)
        {
            //Validation
            var validation = new SaveCourseRessourceValidator();

            var validationResult =  await validation.ValidateAsync(saveCourseRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Create de couurse
            var course = await _courseService.GetCourseById(id);
            if (course == null) return BadRequest("le course n'existe pas");
            //Mappage
            var courseUpdate = _mapperServie.Map<SaveCourseRessource,Course>(saveCourseRessource);
            await _courseService.UpdateCourse(course,courseUpdate);
            var courseNew = await _courseService.GetCourseById(id);
            var courseRessourceUpdate = _mapperServie.Map<Course,CourseRessource>(courseUpdate);
            return Ok(courseRessourceUpdate);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<CourseRessource>> UpdatePathCreate(int id,UpdateCourseRessource updateCourseRessource)
        {
            //Validation
            var validation = new UpdateCourseRessourceValidator();

            var validationResult =  await validation.ValidateAsync(updateCourseRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Create de couurse
            var course = await _courseService.GetCourseById(id);
            if (course == null) return BadRequest("le course n'existe pas");
           
            //Mappage
            var courseUpdate = _mapperServie.Map<UpdateCourseRessource,Course>(updateCourseRessource);
            await _courseService.UpdateCourse(course,courseUpdate);
            var courseNew = await _courseService.GetCourseById(id);
            if (course.CourseName != null)
            {
                courseNew.Score = course.Score;
                course.StudentId = course.StudentId;
            }
            var courseRessourceUpdate = _mapperServie.Map<Course,CourseRessource>(courseUpdate);
            return Ok(courseRessourceUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMusic(int id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null) return BadRequest("Le course n'existe pas");
            await _courseService.DeleteCourse(course);

            return NoContent();
        }
    }
}
