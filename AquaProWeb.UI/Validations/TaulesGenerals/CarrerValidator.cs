using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using FluentValidation;

namespace AquaProWeb.UI.Validations
{
    public class CarrerValidator : AbstractValidator<CreateCarrerDTO>
    {
        // regles de validació + missatges error
        public CarrerValidator()
        {

            RuleFor(t => t.Nom)
                .NotEmpty().WithMessage("El Nom del carrer no pot estar en blanc")
                .MaximumLength(50).WithMessage("El Nom del carrer no pot superar els 50 caracters");

            RuleFor(x => x.CodiPostal)
                .Matches(@"^\d{5}$")
                .WithMessage("El código postal debe contener exactamente 5 números.");

            RuleFor(t => t.Observacions)
                .MaximumLength(255).WithMessage("Les observacions no poden superar els 255 caracters");
        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CreateCarrerDTO>.CreateWithOptions((CreateCarrerDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
