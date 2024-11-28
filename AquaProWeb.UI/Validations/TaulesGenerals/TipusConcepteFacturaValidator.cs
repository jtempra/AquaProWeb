using AquaProWeb.Common.Responses.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class TipusConcepteFacturaValidator : AbstractValidator<ReadTipusConcepteFacturaDTO>
	{
		public TipusConcepteFacturaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusConcepteFacturaDTO>.CreateWithOptions((ReadTipusConcepteFacturaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
