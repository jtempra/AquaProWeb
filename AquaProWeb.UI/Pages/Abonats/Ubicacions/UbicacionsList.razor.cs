
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.Ubicacions
{
    public partial class UbicacionsList
    {
        public List<ReadUbicacioDTO> Ubicacions { get; set; } = [];
        private bool _loading = true;

        private string _searchString = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadUbicacionsAsync();
        }

        private async Task LoadUbicacionsAsync()
        {
            var response = await _ubicacioService.GetAllUbicacionsAsync();
            if (response.IsSuccessful)
            {
                Ubicacions = response.Data;
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

        private async Task AddUbicacioAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddUbicacioDialog>("Crear Punt", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                // TODO caldria recarregar la llista de carrers
                _snackbar.Add("Tot correcte!", Severity.Success);
            }
        }

        private async Task UpdateUbicacioAsync(int Id)
        {
            var parameters = new DialogParameters();

            // el carrer a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la BD

            var response = await _ubicacioService.GetUbicacioByIdAsync(Id);
            if (response.IsSuccessful)
            {
                var ubicacio = response.Data;
                parameters.Add(nameof(UpdateUbicacioDialog.ReadUbicacioDto), ubicacio);
            }


            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdateUbicacioDialog>("Actualitzar Punt Subministrament", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadUbicacionsAsync();
            }
        }
        private async Task DeleteUbicacioAsync(int Id)
        {
            string miss = $"Seguro que quiere borrar el punt subministrament {Id}?";
            var parameters = new DialogParameters()
            {
                {nameof(Shared.DeleteConfirmationDialog.Message),miss}
            };

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Small,
                FullWidth = true
            };

            var dialog = _dialogService.Show<Shared.DeleteConfirmationDialog>("Esborrar Punt Subministrament", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                var response = await _ubicacioService.DeleteUbicacioAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadUbicacionsAsync();
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


        private Func<ReadUbicacioDTO, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            //if (x.Nom.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            //    return true;

            //if (x.PrimerCognom.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            //    return true;

            //if (x.SegonCognom.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            //    return true;

            //if ($"{x.Number} {x.Position} {x.Molar}".Contains(_searchString))
            //    return true;

            return false;
        };
    }
}
