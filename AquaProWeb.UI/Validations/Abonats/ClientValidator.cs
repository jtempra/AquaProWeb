using AquaProWeb.Common.Responses.Abonats.Clients;
using FluentValidation;

namespace AquaProWeb.UI.Validations.Abonats
{
    public class ClientValidator : AbstractValidator<ReadClientDTO>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Nom)
            .NotEmpty().WithMessage("El Nom del client no pot estar en blanc")
            .MaximumLength(50).WithMessage("El Nom del client no pot superar els 50 caracters");
        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadClientDTO>.CreateWithOptions((ReadClientDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }


}
