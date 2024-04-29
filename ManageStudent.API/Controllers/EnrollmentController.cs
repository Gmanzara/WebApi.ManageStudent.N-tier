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
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IMapper _mapperServie;
        public EnrollmentController(IEnrollmentService enrollmentService, IMapper mapperServie)
        {
            _enrollmentService = enrollmentService;
            _mapperServie = mapperServie;
        }
        //[SwaggerOperation("GetStudentList")]
        [HttpGet("/api/Enrollments/", Name = "GetEnrollmenttList")]
        public async Task<ActionResult<IEnumerable<EnrollmentRessource>>> GetAllEnrollment()
        {
            try
            {
                var enrollments = await _enrollmentService.GetAllWithEnrollment();
                var enrollmentRessources = _mapperServie.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentRessource>>(enrollments);
                return Ok(enrollmentRessources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EnrollmentRessource>>> GetEnrollmentById(int id)
        {
            try
            {
                var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
                if (enrollment == null) return NotFound();
                var enrollmentRessource = _mapperServie.Map<Enrollment, EnrollmentRessource>(enrollment);
                return Ok(enrollmentRessource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<EnrollmentRessource>> CreateEnrollment(SaveEnrollmentRessource saveEnrollmentRessource)
        {
            //Validation
            var validation = new SaveEnrollmentRessourceValidator();

            var validationResult = await validation.ValidateAsync(saveEnrollmentRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Mappage
            var Enrollment = _mapperServie.Map<SaveEnrollmentRessource, Enrollment>(saveEnrollmentRessource);
            //Create de couurse
            var newEnrollment = await _enrollmentService.CreateEnrollment(Enrollment);
            //Mappage
            var enrollmentRessource = _mapperServie.Map<Enrollment, EnrollmentRessource>(newEnrollment);
            return Ok(enrollmentRessource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnrollmentRessource>> UpdateEnrollment(int id, SaveEnrollmentRessource saveEnrollmentRessource)
        {
            //Validation
            var validation = new SaveEnrollmentRessourceValidator();

            var validationResult = await validation.ValidateAsync(saveEnrollmentRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Create de couurse
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null) return BadRequest("le Enrollment n'existe pas");
            //Mappage
            var enrollmentUpdate = _mapperServie.Map<SaveEnrollmentRessource, Enrollment>(saveEnrollmentRessource);
            await _enrollmentService.UpdateEnrollment(enrollment,enrollmentUpdate);
            var enrollmentNew = await _enrollmentService.GetEnrollmentByIdAsync(id);
            var enrollmentRessourceUpdate = _mapperServie.Map<Enrollment, EnrollmentRessource>(enrollmentNew);
            return Ok(enrollmentRessourceUpdate);
        }


         [HttpPatch("{id}")]
        public async Task<ActionResult<EnrollmentRessource>> UpdatePatchEnrollment(int id, SaveEnrollmentRessource saveEnrollmentRessource)
        {
            //Validation
            var validation = new SaveEnrollmentRessourceValidator();

            var validationResult = await validation.ValidateAsync(saveEnrollmentRessource);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Create de couurse
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null) return BadRequest("le Enrollment n'existe pas");
            //Mappage
            var enrollmentUpdate = _mapperServie.Map<SaveEnrollmentRessource, Enrollment>(saveEnrollmentRessource);
            await _enrollmentService.UpdateEnrollment(enrollment,enrollmentUpdate);
            var enrollmentNew = await _enrollmentService.GetEnrollmentByIdAsync(id);
            var enrollmentRessourceUpdate = _mapperServie.Map<Enrollment, EnrollmentRessource>(enrollmentNew);
            return Ok(enrollmentRessourceUpdate);
        }
      
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null) return BadRequest("Le enrollment n'existe pas");
            await _enrollmentService.DeleteEnrollment(enrollment);

            return NoContent();
        }
    }
}
