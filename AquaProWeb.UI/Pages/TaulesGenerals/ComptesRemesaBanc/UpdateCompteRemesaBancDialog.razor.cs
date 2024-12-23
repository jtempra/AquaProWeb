using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.ComptesRemesaBanc
{
    public partial class UpdateCompteRemesaBancDialog
    {

        [Parameter]
        public ReadCompteRemesaBancDTO ReadCompteRemesaBancDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        public SaveCompteRemesaBancDTO UpdateCompteRemesaBancDto { get; set; } = new();

        private async Task SaveAsync()
        {
            UpdateCompteRemesaBancDto = ReadCompteRemesaBancDto.Adapt<SaveCompteRemesaBancDTO>();
            var response = await _compteRemesaBancService.UpdateCompteRemesaBancAsync(UpdateCompteRemesaBancDto);
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
