using AquaProWeb.Common.Responses.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusQueixes;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class TipusOrdreTreballValidator : AbstractValidator<ReadTipusOrdreTreballDTO>
	{
		public TipusOrdreTreballValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadTipusOrdreTreballDTO>.CreateWithOptions((ReadTipusOrdreTreballDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
