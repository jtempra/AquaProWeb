using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesConcepteFactura;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class FamiliaConcepteFacturaValidator : AbstractValidator<ReadFamiliaConcepteFacturaDTO>
	{
		public FamiliaConcepteFacturaValidator()
		{
			
		}

	// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadFamiliaConcepteFacturaDTO>.CreateWithOptions((ReadFamiliaConcepteFacturaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};
		
	}
}
