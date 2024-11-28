using AquaProWeb.Common.Responses.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class ZonaOrdreTreballValidator : AbstractValidator<ReadZonaOrdreTreballDTO>
	{
		public ZonaOrdreTreballValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadZonaOrdreTreballDTO>.CreateWithOptions((ReadZonaOrdreTreballDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
