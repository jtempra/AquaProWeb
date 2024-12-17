using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Requests.Abonats.Clients;
using AquaProWeb.UI.Validations.Abonats;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.Clients
{
    public partial class AddClientDialog
    {
        [Parameter]
        public CreateClientDTO CreateClientDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;

        public ClientValidator clientValidator = new();

        private TipusContacte TipusContacte { get; set; }
        private TipusDocumentIdentificacio TipusDocument { get; set; }
        private async Task Submit()
        {
            await _form.Validate();

            if (_form.IsValid)
            {
                var response = await _clientService.AddClientAsync(CreateClientDto);
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
            else
            {
                _snackbar.Add("lalala", Severity.Error);
                MudDialog.Close();
            }
        }

        private void Cancel() => MudDialog.Cancel();

    }
}
