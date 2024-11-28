using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class TipusUbicacioValidator : AbstractValidator<ReadTipusUbicacioDTO>
	{
		public TipusUbicacioValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusUbicacioDTO>.CreateWithOptions((ReadTipusUbicacioDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
