using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Requests.Abonats.Clients;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.UI.Validations.Abonats;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.Clients
{
    public partial class AddClientDialog
    {
        [Parameter]
        public ReadClientDTO ReadClientDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;

        public ClientValidator clientValidator = new();

        private TipusContacte TipusContacte { get; set; }
        private TipusDocumentIdentificacio TipusDocument { get; set; }
        private List<ReadTipusViaDTO> TipusVies { get; set; } = [];
        private List<ReadPaisDTO> Paisos { get; set; } = [];
        private List<ReadTipusClientDTO> TipusClients { get; set; } = [];
        public SaveClientDTO CreateClientDto { get; set; } = new();

        protected override async void OnInitialized()
        {
            var responseTipusVia = await _tipusViaService.GetAllTipusViaAsync();
            TipusVies = responseTipusVia.Data;
            var responseTipusClient = await _tipusClientService.GetAllTipusClientsAsync();
            TipusClients = responseTipusClient.Data;
			var responsePaisos = await _paisService.GetAllPaisosAsync();
            Paisos = responsePaisos.Data;
        }
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
                _snackbar.Add("validació incorrecte", Severity.Error);
                MudDialog.Close();
            }
        }

        private void Cancel() => MudDialog.Cancel();

    }
}
