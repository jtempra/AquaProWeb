using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusOrdresTreball;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class TipusIncidenciaUbicacioValidator : AbstractValidator<ReadTipusIncidenciaUbicacioDTO>
	{
		public TipusIncidenciaUbicacioValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusIncidenciaUbicacioDTO>.CreateWithOptions((ReadTipusIncidenciaUbicacioDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
