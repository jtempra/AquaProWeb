using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitularCompte;
using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class OperariValidator : AbstractValidator<ReadOperariDTO>
	{
		public OperariValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadOperariDTO>.CreateWithOptions((ReadOperariDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
