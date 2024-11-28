
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using FluentValidation;

namespace AquaProWeb.UI.Validations
{
    public class CanalCobramentValidator : AbstractValidator<CreateCanalCobramentDTO>
    {
        // regles de validació + missatges error
        public CanalCobramentValidator()
        {
            RuleFor(t => t.Canal)
                .NotEmpty().WithMessage("El nom del canal no pot estar en blanc")
                .MaximumLength(100).WithMessage("El nom del canal no pot superar els 100 caracters");
            RuleFor(x => x.FormaPagament)
                .IsInEnum()
                .WithMessage("El valor de la forma de pago no es válido.");
            RuleFor(t => t.Descripcio)
                .MaximumLength(255).WithMessage("La descripció no pot superar els 255 caracters");
            RuleFor(t => t.Observacions)
                .MaximumLength(1000).WithMessage("Les observacions no pot superar els 1000 caracters");
            RuleFor(t => t.BIC)
                .MaximumLength(50).WithMessage("El BIC no pot superar els 50 caracters");
        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CreateCanalCobramentDTO>.CreateWithOptions((CreateCanalCobramentDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
