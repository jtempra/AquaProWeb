using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class PaisValidator : AbstractValidator<ReadPaisDTO>
	{
		public PaisValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadPaisDTO>.CreateWithOptions((ReadPaisDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
