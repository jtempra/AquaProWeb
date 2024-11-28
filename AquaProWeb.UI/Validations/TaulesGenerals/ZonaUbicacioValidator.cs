using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class ZonaUbicacioValidator : AbstractValidator<ReadZonaUbicacioDTO>
	{
		public ZonaUbicacioValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadZonaUbicacioDTO>.CreateWithOptions((ReadZonaUbicacioDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
