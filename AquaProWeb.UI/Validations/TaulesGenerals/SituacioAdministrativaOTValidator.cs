using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsAdministrativesOT;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
    public class SituacioAdministrativaOTValidator : AbstractValidator<ReadSituacioAdministrativaOTDTO>
    {
        public SituacioAdministrativaOTValidator()
        {

        }

        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadSituacioAdministrativaOTDTO>.CreateWithOptions((ReadSituacioAdministrativaOTDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };

    }
}
