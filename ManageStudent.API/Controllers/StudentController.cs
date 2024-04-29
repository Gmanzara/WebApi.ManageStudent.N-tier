using AutoMapper;
using ManageStudent.API.Ressources;
using ManageStudent.API.Validation;
using ManageStudent.Core.Models;
using ManageStudent.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ManageStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapperServie;
        public StudentController(IStudentService studentService, IMapper mapperServie)
        {
            _studentService = studentService;
            _mapperServie = mapperServie;
        }
        //[SwaggerOperation("GetStudentList")]
        [HttpGet("/api/Students/", Name = "GetStudentList")]
        public async Task<ActionResult<IEnumerable<StudentRessource>>> GetAllStudent()
        {
            try
            {
                var Student = await _studentService.GetAllWithStudent();
                var StudentRessources = _mapperServie.Map<IEnumerable<Student>, IEnumerable<StudentRessource>>(Student);
                return Ok(StudentRessources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StudentRessource>>> GetStudentById(int id)
        {
            try
            {
                var Student = await _studentService.GetStudentByIdAsync(id);
                if (Student == null) return NotFound();
                var StudentRessource = _mapperServie.Map<Student, StudentRessource>(Student);
                return Ok(StudentRessource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<StudentRessource>> CreateStudent(SaveStudentRessource saveStudentRessource)
        {
            //Validation
            var validation = new SaveStudentRessourceValidator();

            var validationResult = await validation.ValidateAsync(saveStudentRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Mappage
            var student = _mapperServie.Map<SaveStudentRessource, Student>(saveStudentRessource);
            //Create de couurse
            var newStudent = await _studentService.CreateStudent(student);
            //Mappage
            var studentRessource = _mapperServie.Map<Student, StudentRessource>(newStudent);
            return Ok(studentRessource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentRessource>> UpdateStudent(int id, SaveStudentRessource saveStudentRessource)
        {
            //Validation
            var validation = new SaveStudentRessourceValidator();

            var validationResult = await validation.ValidateAsync(saveStudentRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Create de couurse
            var Student = await _studentService.GetStudentByIdAsync(id);
            if (Student == null) return BadRequest("le Student n'existe pas");
            //Mappage
            var StudentUpdate = _mapperServie.Map<SaveStudentRessource, Student>(saveStudentRessource);
            await _studentService.UpdateStudent(Student,StudentUpdate);
            var StudentNew = await _studentService.GetStudentByIdAsync(id);
            var StudentRessourceUpdate = _mapperServie.Map<Student, StudentRessource>(StudentNew);
            return Ok(StudentRessourceUpdate);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<StudentRessource>> UpdatePathStudent(int id, SaveStudentRessource saveStudentRessource)
        {
            //Validation
            var validation = new SaveStudentRessourceValidator();

            var validationResult = await validation.ValidateAsync(saveStudentRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Create de couurse
            var Student = await _studentService.GetStudentByIdAsync(id);
            if (Student == null) return BadRequest("le Student n'existe pas");
            //Mappage
            var StudentUpdate = _mapperServie.Map<SaveStudentRessource, Student>(saveStudentRessource);
            await _studentService.UpdateStudent(Student,StudentUpdate);
            var StudentNew = await _studentService.GetStudentByIdAsync(id);
            var StudentRessourceUpdate = _mapperServie.Map<Student, StudentRessource>(StudentNew);
            return Ok(StudentRessourceUpdate);
        }
     
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMusic(int id)
        {
            var Student = await _studentService.GetStudentByIdAsync(id);
            if (Student == null) return BadRequest("Le Student n'existe pas");
            await _studentService.DeleteStudent(Student);

            return NoContent();
        }
    }
}
