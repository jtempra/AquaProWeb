using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesContracte;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class FamiliaContracteValidator : AbstractValidator<ReadFamiliaContracteDTO>
	{
		public FamiliaContracteValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadFamiliaContracteDTO>.CreateWithOptions((ReadFamiliaContracteDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
