using AquaProWeb.Common.Responses.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class UsContracteValidator : AbstractValidator<ReadUsContracteDTO>
	{
		public UsContracteValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadUsContracteDTO>.CreateWithOptions((ReadUsContracteDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
