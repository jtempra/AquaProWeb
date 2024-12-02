using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
    public class ConcepteCobramentValidator : AbstractValidator<ReadConcepteCobramentDTO>
    {
        public ConcepteCobramentValidator()
        {
            RuleFor(t => t.Concepte)
            .NotEmpty().WithMessage("El concepte de cobrament no pot estar en blanc")
            .MaximumLength(50).WithMessage("El concepte de cobrament no pot superar els 50 caracters");
            RuleFor(t => t.Descripcio)
                .MaximumLength(255).WithMessage("La descripció no pot superar els 255 caracters");
            RuleFor(t => t.Observacions)
                .MaximumLength(2000).WithMessage("Les observacions no podent superar els 2000 caracters");
            RuleFor(t => t.CodiComptable)
                .MaximumLength(50).WithMessage("El codi comptable no pot superar els 50 caracters");
        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadConcepteCobramentDTO>.CreateWithOptions((ReadConcepteCobramentDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };

    }
}
