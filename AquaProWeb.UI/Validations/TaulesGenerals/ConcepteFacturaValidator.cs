using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
    public class ConcepteFacturaValidator : AbstractValidator<ReadConcepteFacturaDTO>
    {
        public ConcepteFacturaValidator()
        {
            RuleFor(c => c.Codi)
            .NotEmpty().WithMessage("El codi de concepte no pot estar en blanc")
            .MaximumLength(12).WithMessage("El codi de concepte no pot superar els 12 caracters");

            RuleFor(c => c.Descripcio)
            .NotEmpty().WithMessage("La descripció del concepte no pot estar en blanc")
            .MaximumLength(255).WithMessage("La descripció del concepte no pot superar els 255 caracters");

            RuleFor(c => c.Observacions)
            .NotEmpty().WithMessage("La descripció del concepte no pot estar en blanc")
            .MaximumLength(255).WithMessage("La descripció del concepte no pot superar els 255 caracters");

            RuleFor(c => c.PVP)
            .NotEmpty().WithMessage("El PVP del concepte no pot estar en blanc")
            .GreaterThan(0).WithMessage("El PVP del concepte te que ser mes gran de 0");
        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadConcepteFacturaDTO>.CreateWithOptions((ReadConcepteFacturaDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };

    }
}
