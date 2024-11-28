using AquaProWeb.Common.Responses.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class TipusSuggerimentValidator : AbstractValidator<ReadTipusSuggerimentDTO>
	{
		public TipusSuggerimentValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusSuggerimentDTO>.CreateWithOptions((ReadTipusSuggerimentDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
