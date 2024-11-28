using AquaProWeb.Common.Responses.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesOrdresTreball;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class ZonaFacturacioValidator : AbstractValidator<ReadZonaFacturacioDTO>
	{
		public ZonaFacturacioValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadZonaFacturacioDTO>.CreateWithOptions((ReadZonaFacturacioDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
