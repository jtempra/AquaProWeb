using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesLectures;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class TipusIncidenciaContracteValidator : AbstractValidator<ReadTipusIncidenciaContracteDTO>
	{
		public TipusIncidenciaContracteValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusIncidenciaContracteDTO>.CreateWithOptions((ReadTipusIncidenciaContracteDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
