using FluentValidation;
using ManageStudent.API.Ressources;

namespace ManageStudent.API.Validation
{
    public class SaveComposerRessourceValidator : AbstractValidator<SaveComposerRessource>
    {
        public SaveComposerRessourceValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(m => m.LastName).NotEmpty().MaximumLength(50);
        }

    }
}
