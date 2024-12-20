using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Responses.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.UI.Validations.PuntsSubministrament;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.PuntsSubministrament
{
    partial class AddPuntSubministramentDialog
    {
        [Parameter]
        public ReadPuntSubministramentDTO ReadPuntSubministramentDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;

        public PuntSubministramentValidator puntSubministramentValidator = new();

        private List<ReadTipusUbicacioDTO> TipusUbicacions { get; set; } = [];
        private List<ReadZonaUbicacioDTO> ZonesUbicacio { get; set; } = [];
        private List<ReadPoblacioDTO> Poblacions { get; set; } = [];
        private List<ReadCarrerDTO> Carrers { get; set; } = [];
        private List<ReadEscomesaDTO> Escomeses { get; set; } = [];
        private List<ReadRutaLecturaDTO> RutesLectura { get; set; } = [];
        public CreatePuntSubministramentDTO CreatePuntSubministramentDto { get; set; } = new();

        protected override async void OnInitialized()
        {
            var responseTipus = await _tipusUbicacioService.GetAllTipusUbicacionsAsync();
            TipusUbicacions = responseTipus.Data;
            var responseZones = await _zonesUbicacioService.GetAllZonesUbicacioAsync();
            ZonesUbicacio = responseZones.Data;
            var responsePoblacions = await _poblacionsService.GetAllPoblacionsAsync();
            Poblacions = responsePoblacions.Data;
            var responseCarrers = await _carrersService.GetAllCarrersAsync();
            Carrers = responseCarrers.Data;
            var responseEscomeses = await _escomesesService.GetAllEscomesesAsync();
            Escomeses = responseEscomeses.Data;
            var responseRutes = await _rutesLecturaService.GetAllRutesLecturaAsync();
            RutesLectura = responseRutes.Data;
        }
        private async Task Submit()
        {
            await _form.Validate();

            if (_form.IsValid)
            {
                var response = await _puntSubministramentService.AddPuntSubministramentAsync(CreatePuntSubministramentDto);
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
