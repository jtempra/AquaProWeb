
using AquaProWeb.Common.Requests.Explotacions;
using FluentValidation;


namespace AquaProWeb.UI.Validations;
public class ExplotacioValidator : AbstractValidator<CreateExplotacioDTO>
{
    // regles de validació + missatges error
    public ExplotacioValidator()
    {
        RuleFor(t => t.Codi)
                .NotEmpty().WithMessage("El Codi de la Explotació no pot estar en blanc")
                .MaximumLength(25).WithMessage("El Codi de la Explotació no pot superar els 25 caracters");

        RuleFor(t => t.Nom)
                .NotEmpty().WithMessage("El Nom de la Explotació no pot estar en blanc")
                .MaximumLength(255).WithMessage("El Nom de la Explotació no pot superar els 255 caracters");

    }

    // funció de validació
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateExplotacioDTO>.CreateWithOptions((CreateExplotacioDTO)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
