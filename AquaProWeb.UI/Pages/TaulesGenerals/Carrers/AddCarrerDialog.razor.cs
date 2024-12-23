using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.Carrers
{
    public partial class AddCarrerDialog
    {
        [Parameter]
        //public CreateCarrerDTO CreateCarrerDto { get; set; } = new();
        public ReadCarrerDTO ReadCarrerDto { get; set; } = new();

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private MudForm _form = default;
        private List<ReadPoblacioDTO> Poblacions { get; set; } = [];
        private List<ReadTipusViaDTO> TipusVies { get; set; } = [];
        private List<ReadZonaCarrerDTO> ZonesCarrers { get; set; } = [];
        private CategoriaVia CategoriesVia { get; set; }
        public SaveCarrerDTO CreateCarrerDto { get; set; } = new();
        protected override async void OnInitialized()
        {
            var responsePoblacions = await _poblacioService.GetAllPoblacionsAsync();
            Poblacions = responsePoblacions.Data;
            var responseZones = await _zonaCarrerService.GetAllZonesCarrerAsync();
            ZonesCarrers = responseZones.Data;
            var responseTipus = await _tipusViaService.GetAllTipusViaAsync();
            TipusVies = responseTipus.Data;
        }
        private async Task SaveAsync()
        {
            CreateCarrerDto = ReadCarrerDto.Adapt<SaveCarrerDTO>();
            var response = await _carrerService.AddCarrerAsync(CreateCarrerDto);
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
