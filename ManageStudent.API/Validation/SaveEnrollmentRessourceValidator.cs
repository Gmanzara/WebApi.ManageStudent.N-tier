using FluentValidation;
using ManageStudent.API.Ressources;

namespace ManageStudent.API.Validation
{
    public class SaveEnrollmentRessourceValidator : AbstractValidator<SaveEnrollmentRessource>
    {
        public SaveEnrollmentRessourceValidator()
        {

            RuleFor(c => c.Score)
                .NotEmpty()
                .WithMessage("'Score' doit pas à nul")
                .GreaterThanOrEqualTo(0)
                .WithMessage("'Score' doit supérieur à 0");
        }
    } 
    public class SaveUserRessourceValidator : AbstractValidator<SaveUserRessource>
    {
        public SaveUserRessourceValidator()
        {

            RuleFor(c => c.FirstName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(c => c.LastName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(c => c.UserName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
