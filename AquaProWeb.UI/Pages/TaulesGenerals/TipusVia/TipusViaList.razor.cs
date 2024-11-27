using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.TipusVia
{
    public partial class TipusViaList
    {
        public List<ReadTipusViaDTO> TipusVia { get; set; } = [];
        private bool _loading = true;


        private async Task LoadTipusViaAsync()
        {
            var response = await _tipusViaService.GetAllTipusViaAsync();
            if (response.IsSuccessful)
            {
                TipusVia = response.Data;
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
            await LoadTipusViaAsync();
        }

        private async Task AddTipusViaAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddTipusViaDialog>("Crear Tipus Via", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadTipusViaAsync();
            }
        }

        private async Task UpdateTipusViaAsync(int Id)
        {
            var parameters = new DialogParameters();

            var tipusVia = TipusVia.FirstOrDefault(t => t.Id == Id);


            parameters.Add(nameof(UpdateTipusViaDialog.UpdateTipusViaDto), new UpdateTipusViaDTO()
            {
                Id = tipusVia.Id,
                Codi = tipusVia.Codi,
                Descripcio = tipusVia.Descripcio,
                Observacions = tipusVia.Observacions
            });

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdateTipusViaDialog>("Actualitzar Tipus de Via", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadTipusViaAsync();
            }
        }

        private async Task DeleteTipusViaAsync(int Id, string Codi)
        {

            string miss = $"Seguro que quiere borrar el tipo de via {Codi}?";
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
                    await LoadTipusViaAsync();
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