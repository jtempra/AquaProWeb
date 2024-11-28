using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class PoblacioValidator : AbstractValidator<ReadPoblacioDTO>
	{
		public PoblacioValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadPoblacioDTO>.CreateWithOptions((ReadPoblacioDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
