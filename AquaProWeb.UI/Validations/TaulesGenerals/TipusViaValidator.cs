using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.UsosContracte;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class TipusViaValidator : AbstractValidator<ReadTipusViaDTO>
	{
		public TipusViaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusViaDTO>.CreateWithOptions((ReadTipusViaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
