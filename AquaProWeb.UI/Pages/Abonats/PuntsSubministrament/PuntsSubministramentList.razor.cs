using AquaProWeb.Common.Responses.Abonats.PuntsSubministrament;
using MudBlazor;

namespace AquaProWeb.UI.Pages.Abonats.PuntsSubministrament
{
    public partial class PuntsSubministramentList
    {
        public List<ReadPuntSubministramentDTO> PuntsSubministrament { get; set; } = [];
        private bool _loading = true;

        private string _searchString = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadPuntsSubministramentAsync();
        }

        private async Task LoadPuntsSubministramentAsync()
        {
            var response = await _puntSubministramentService.GetAllPuntsSubministramentAsync();
            if (response.IsSuccessful)
            {
                PuntsSubministrament = response.Data;
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

        private async Task AddPuntSubministramentAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddPuntSubministramentDialog>("Crear Punt", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                // TODO caldria recarregar la llista de carrers
                _snackbar.Add("Tot correcte!", Severity.Success);
            }
        }

        private async Task UpdatePuntSubministramentAsync(int Id)
        {
            var parameters = new DialogParameters();

            // el carrer a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la BD

            var response = await _puntSubministramentService.GetPuntSubministramentByIdAsync(Id);
            if (response.IsSuccessful)
            {
                var puntSubministrament = response.Data;
                parameters.Add(nameof(UpdatePuntSubministramentDialog.ReadPuntSubministramentDto), puntSubministrament);
            }


            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdatePuntSubministramentDialog>("Actualitzar Punt Subministrament", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadPuntsSubministramentAsync();
            }
        }
        private async Task DeletePuntSubministramentAsync(int Id)
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
                var response = await _puntSubministramentService.DeletePuntSubministramentAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadPuntsSubministramentAsync();
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


        private Func<ReadPuntSubministramentDTO, bool> _quickFilter => x =>
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
