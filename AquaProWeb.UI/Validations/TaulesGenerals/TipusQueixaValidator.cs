using AquaProWeb.Common.Responses.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusReclamacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class TipusQueixaValidator : AbstractValidator<ReadTipusQueixaDTO>
	{
		public TipusQueixaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusQueixaDTO>.CreateWithOptions((ReadTipusQueixaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
