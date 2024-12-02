using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using FluentValidation;

namespace AquaProWeb.UI.Validations
{
    public class CompteRemesaBancValidator : AbstractValidator<ReadCompteRemesaBancDTO>
    {
        // regles de validació + missatges error
        public CompteRemesaBancValidator()
        {

            RuleFor(t => t.Descripcio)
                .MaximumLength(255).WithMessage("La descripció no pot superar els 255 caracters");

            RuleFor(x => x.IBAN)
                .Matches(@"^[A-Z]{2}\d{2}[A-Z0-9]{1,30}$")
                .WithMessage("Posible IBAN incorrecto");

            RuleFor(x => x.BIC)
                .Matches(@"^[A-Za-z]{4}[A-Za-z]{2}[A-Za-z0-9]{2}([A-Za-z0-9]{3})?$")
                .WithMessage("Posible BIC incorrecto");

            RuleFor(t => t.Sufixe).Matches(@"^\d{3}$").WithMessage("El sufixe ha de tenir 3 digits");

        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadCompteRemesaBancDTO>.CreateWithOptions((ReadCompteRemesaBancDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
