using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
    public class MotiuBaixaComptadorValidator : AbstractValidator<ReadMotiuBaixaComptadorDTO>
    {
        public MotiuBaixaComptadorValidator()
        {

        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadMotiuBaixaComptadorDTO>.CreateWithOptions((ReadMotiuBaixaComptadorDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };

    }
}
