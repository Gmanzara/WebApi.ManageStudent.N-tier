using FluentValidation;
using ManageStudent.API.Ressources;

namespace ManageStudent.API.Validation
{
    public class UpdateCourseRessourceValidator : AbstractValidator<UpdateCourseRessource>
    {
        public UpdateCourseRessourceValidator()
        {
            RuleFor(c => c.CourseName)
                .NotEmpty()
                .MaximumLength(50);

        }
    }

}
