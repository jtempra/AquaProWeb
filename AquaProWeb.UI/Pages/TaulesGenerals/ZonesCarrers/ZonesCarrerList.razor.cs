using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.ZonesCarrers
{
    public partial class ZonesCarrerList
    {
        public List<ReadZonaCarrerDTO> ZonesCarrer { get; set; } = [];
        private bool _loading = true;


        private async Task LoadZonesCarrerAsync()
        {
            var response = await _zonaCarrerService.GetAllZonesCarrerAsync();
            if (response.IsSuccessful)
            {
                ZonesCarrer = response.Data;
            }
            else
            {
                foreach (var miss in response.Messages)
                {
                    _snackbar.Add(miss, Severity.Error);
                }
            }

            _loading = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadZonesCarrerAsync();
        }

        private async Task AddZonaCarrerAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddZonaCarrerDialog>("Crear Zona Carrer", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadZonesCarrerAsync();
            }
        }

        private async Task UpdateZonaCarrerAsync(int Id)
        {
            var parameters = new DialogParameters();

            var zonaCarrer = ZonesCarrer.FirstOrDefault(t => t.Id == Id);


            parameters.Add(nameof(UpdateZonaCarrerDialog.UpdateZonaCarrerDto), new SaveZonaCarrerDTO()
            {
                Id = zonaCarrer.Id,
                Zona = zonaCarrer.Zona,
                Descripcio = zonaCarrer.Descripcio,
                Observacions = zonaCarrer.Observacions
            });

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdateZonaCarrerDialog>("Actualitzar Zona Carrer", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadZonesCarrerAsync();
            }
        }

        private async Task DeleteZonaCarrerAsync(int Id, string Zona)
        {

            string miss = $"Seguro que quiere borrar la zona de calles {Zona}?";
            var parameters = new DialogParameters()
            {
                { nameof(Shared.DeleteConfirmationDialog.Message), miss }
            };

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            var dialog =
                _dialogService.Show<Shared.DeleteConfirmationDialog>("Esborrar Tipus de Via", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                var response = await _tipusViaService.DeleteTipusViaAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadZonesCarrerAsync();
                    _snackbar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    foreach (var message in response.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }

        }
    }
}