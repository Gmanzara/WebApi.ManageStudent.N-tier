using FluentValidation;
using ManageStudent.API.Ressources;

namespace ManageStudent.API.Validation
{
    public class SaveCourseRessourceValidator : AbstractValidator<SaveCourseRessource>
    {
        public SaveCourseRessourceValidator()
        {
            RuleFor(c => c.CourseName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(c => c.Score)
                .NotEmpty()
                .WithMessage("'Score' doit pas à nul")
                .GreaterThanOrEqualTo(0)
                .WithMessage("'Score' doit supérieur à 0");  
        }
    }

}
