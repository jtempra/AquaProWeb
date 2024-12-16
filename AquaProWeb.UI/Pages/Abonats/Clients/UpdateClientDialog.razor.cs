using AquaProWeb.Common.Requests.Abonats.Clients;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.Clients
{
    public partial class UpdateClientDialog
    {
        [Parameter]
        public ReadClientDTO ReadClientDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private List<ReadTipusClientDTO> TipusClient { get; set; } = [];
        private List<ReadTipusViaDTO> TipusVies { get; set; } = [];
        private List<ReadPaisDTO> Paisos { get; set; } = [];
        public UpdateClientDTO UpdateClientDto { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var responseTipusClients = await _tipusClientService.GetAllTipusClientsAsync();
            TipusClient = responseTipusClients.Data;
            var responsePaisos = await _paisService.GetAllPaisosAsync();
            Paisos = responsePaisos.Data;
            var responseTipus = await _tipusViaService.GetAllTipusViaAsync();
            TipusVies = responseTipus.Data;

            StateHasChanged();
        }
        private async Task SaveAsync()
        {
            UpdateClientDto = ReadClientDto.Adapt<UpdateClientDTO>();
            var response = await _carrerService.UpdateClientAsync(UpdateClientDto);
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
