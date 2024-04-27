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
            CreateMap<Course, SaveCourseRessource>().ReverseMap();
            CreateMap<Course, UpdateCourseRessource>().ReverseMap();
            CreateMap<Student, SaveStudentRessource>().ReverseMap();
            CreateMap<Student, UpdateStudentRessource>().ReverseMap();
            CreateMap<Composer, ComposerRessource>().ReverseMap() ;
            CreateMap<Composer, SaveComposerRessource>().ReverseMap();

        }

    }
}
