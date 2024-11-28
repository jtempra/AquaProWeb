using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsRebut;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusComptadors;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class TipusComptadorValidator : AbstractValidator<ReadTipusComptadorDTO>
	{
		public TipusComptadorValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusComptadorDTO>.CreateWithOptions((ReadTipusComptadorDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
