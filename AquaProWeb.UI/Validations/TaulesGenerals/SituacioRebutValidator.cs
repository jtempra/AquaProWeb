using AquaProWeb.Common.Responses.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsRebut;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class SituacioRebutValidator : AbstractValidator<ReadSituacioRebutDTO>
	{
		public SituacioRebutValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadSituacioRebutDTO>.CreateWithOptions((ReadSituacioRebutDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
