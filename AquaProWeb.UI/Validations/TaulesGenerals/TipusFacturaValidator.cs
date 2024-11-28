using AquaProWeb.Common.Responses.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusFactures;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class TipusFacturaValidator : AbstractValidator<ReadTipusFacturaDTO>
	{
		public TipusFacturaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusFacturaDTO>.CreateWithOptions((ReadTipusFacturaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
