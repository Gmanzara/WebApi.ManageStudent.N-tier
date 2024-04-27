using FluentValidation;
using ManageStudent.API.Ressources;

namespace ManageStudent.API.Validation
{
    public class UpdateStudentRessourceValidator : AbstractValidator<UpdateStudentRessource>
    {
        public UpdateStudentRessourceValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(c => c.LastName)
                .NotEmpty()
                .MaximumLength(50);

        }
    }
}
