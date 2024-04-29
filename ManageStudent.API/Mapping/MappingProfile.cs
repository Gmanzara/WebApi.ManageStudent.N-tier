using AutoMapper;
using ManageStudent.API.Ressources;
using ManageStudent.Core.Models;

namespace ManageStudent.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Domain(bd) => Ressource
            CreateMap<Course, CourseRessource>().ReverseMap() ;
            CreateMap<Student,StudentRessource>().ReverseMap();
            CreateMap<Enrollment, EnrollmentRessource>().ReverseMap();
            CreateMap<Course, SaveCourseRessource>().ReverseMap();
            CreateMap<Student, SaveStudentRessource>().ReverseMap();
            CreateMap<Enrollment,SaveEnrollmentRessource>().ReverseMap();
            CreateMap<User,UserRessource>().ReverseMap();
            CreateMap<Composer, ComposerRessource>().ReverseMap() ;
            CreateMap<Composer, SaveComposerRessource>().ReverseMap();

        }

    }
}
