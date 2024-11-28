using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using FluentValidation;

namespace AquaProWeb.UI.Validations
{
	public class ParametreValidator : AbstractValidator<ReadParametreDTO>
	{
		public ParametreValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadParametreDTO>.CreateWithOptions((ReadParametreDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
