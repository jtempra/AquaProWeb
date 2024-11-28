using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class SituacioFacturaValidator : AbstractValidator<ReadSituacioFacturaDTO>
	{
		public SituacioFacturaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadSituacioFacturaDTO>.CreateWithOptions((ReadSituacioFacturaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
