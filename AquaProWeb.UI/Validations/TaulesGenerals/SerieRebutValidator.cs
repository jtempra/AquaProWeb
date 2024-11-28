using AquaProWeb.Common.Responses.TaulesGenerals.SeriesRebut;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class SerieRebutValidator : AbstractValidator<ReadSerieRebutDTO>
	{
		public SerieRebutValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadSerieRebutDTO>.CreateWithOptions((ReadSerieRebutDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
