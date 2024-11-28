using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class TipusIncidenciaTecnicaValidator : AbstractValidator<ReadTipusIncidenciaTecnicaDTO>
	{
		public TipusIncidenciaTecnicaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusIncidenciaTecnicaDTO>.CreateWithOptions((ReadTipusIncidenciaTecnicaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
