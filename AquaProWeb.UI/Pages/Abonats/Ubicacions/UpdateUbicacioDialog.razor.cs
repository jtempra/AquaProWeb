using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.Ubicacions
{
    public partial class UpdateUbicacioDialog
    {
        [Parameter]
        public ReadUbicacioDTO ReadUbicacioDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private List<ReadTipusUbicacioDTO> TipusUbicacions { get; set; } = [];
        private List<ReadZonaUbicacioDTO> ZonesUbicacio { get; set; } = [];
        private List<ReadPoblacioDTO> Poblacions { get; set; } = [];
        private List<ReadCarrerDTO> Carrers { get; set; } = [];
        private List<ReadEscomesaDTO> Escomeses { get; set; } = [];
        private List<ReadRutaLecturaDTO> RutesLectura { get; set; } = [];
        public UpdateUbicacioDTO UpdateUbicacioDto { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var responseTipus = await _tipusUbicacioService.GetAllTipusUbicacioAsync();
            TipusUbicacions = responseTipus.Data;
            var responseZones = await _zonaUbicacioService.GetAllZonesUbicacioAsync();
            ZonesUbicacio = responseZones.Data;
            var responsePoblacions = await _poblacioService.GetAllPoblacionsAsync();
            Poblacions = responsePoblacions.Data;
            var responseCarrers = await _carrerService.GetAllCarrersAsync();
            Carrers = responseCarrers.Data;
            var responseEscomeses = await _escomesaService.GetAllEscomesesAsync();
            Escomeses = responseEscomeses.Data;
            var responseRutes = await _rutaLecturaService.GetAllRutesLecturaAsync();
            RutesLectura = responseRutes.Data;

            StateHasChanged();
        }
        private async Task SaveAsync()
        {
            UpdateUbicacioDto = ReadUbicacioDto.Adapt<UpdateUbicacioDTO>();
            var response = await _ubicacioService.UpdateUbicacioAsync(UpdateUbicacioDto);
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
