
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.PuntsSubministrament
{
    public class UbicacioValidator : AbstractValidator<ReadUbicacioDTO>
    {
        public UbicacioValidator()
        {
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("El número del punt de subministrament no pot estar en blanc");

        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadUbicacioDTO>.CreateWithOptions((ReadUbicacioDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
