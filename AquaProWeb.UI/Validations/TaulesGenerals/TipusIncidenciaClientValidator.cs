using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class TipusIncidenciaClientValidator : AbstractValidator<ReadTipusIncidenciaClientDTO>
	{
		public TipusIncidenciaClientValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusIncidenciaClientDTO>.CreateWithOptions((ReadTipusIncidenciaClientDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
