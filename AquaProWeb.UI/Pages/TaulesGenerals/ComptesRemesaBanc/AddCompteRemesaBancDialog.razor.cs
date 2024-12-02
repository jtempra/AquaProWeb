
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.ComptesRemesaBanc
{

    public partial class AddCompteRemesaBancDialog
    {
        [Parameter]
        public ReadCompteRemesaBancDTO ReadCompteRemesaBancDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        public CreateCompteRemesaBancDTO CreateCompteRemesaBancDto { get; set; } = new();

        private async Task SaveAsync()
        {
            CreateCompteRemesaBancDto = ReadCompteRemesaBancDto.Adapt<CreateCompteRemesaBancDTO>();
            var response = await _compteRemesaBancService.AddCompteRemesaBancAsync(CreateCompteRemesaBancDto);
            if (response.IsSuccessful)
            {
                _snackbar.Add(response.Messages[0], Severity.Success);

                MudDialog.Close();
            }
            else
            {
                foreach (var miss in response.Messages)
                {
                    _snackbar.Add(miss, Severity.Error);
                }
            }
        }

        private void Cancel() => MudDialog.Cancel();
    }

}
