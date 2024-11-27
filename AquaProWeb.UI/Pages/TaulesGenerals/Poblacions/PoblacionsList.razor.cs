
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using MudBlazor;

namespace AquaProWeb.UI.Pages.TaulesGenerals.Poblacions
{
    public partial class PoblacionsList
    {
        public List<ReadPoblacioDTO> Poblacions { get; set; } = [];
        private bool _loading = true;
        protected override async Task OnInitializedAsync()
        {
            var response = await _poblacioService.GetAllPoblacionsAsync();
            if (response.IsSuccessful)
            {
                Poblacions = response.Data;
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

        private async Task LoadPoblacionsAsync()
        {
            var response = await _poblacioService.GetAllPoblacionsAsync();
            if (response.IsSuccessful)
            {
                Poblacions = response.Data;
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

        private async Task AddPoblacioAsync()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<AddPoblacioDialog>("Crear Població", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                // TODO caldria recarregar la llista de poblacions
                _snackbar.Add("Tot correcte!", Severity.Success);
            }
        }

        private async Task UpdatePoblacioAsync(int Id)
        {
            var parameters = new DialogParameters();

            // la poblacio a editar la podem agafar de la taula o be de la BD, aqui l'agafem de la taula

            var poblacio = Poblacions.FirstOrDefault(e => e.Id == Id);


            parameters.Add(nameof(UpdatePoblacioDialog.UpdatePoblacioDto), new UpdatePoblacioDTO()
            {
                Id = poblacio.Id,
                Nom = poblacio.Nom,
                CodiINE = poblacio.CodiINE,
                Observacions = poblacio.Observacions,
                ExplotacioId = poblacio.ExplotacioId
            });

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var dialog = _dialogService.Show<UpdatePoblacioDialog>("Actualitzar Poblacio", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadPoblacionsAsync();
            }
        }
        private async Task DeletePoblacioAsync(int Id, string Nom)
        {
            string miss = $"Seguro que quiere borrar la población {Nom}?";
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

            var dialog = _dialogService.Show<Shared.DeleteConfirmationDialog>("Esborrar població", parameters, options);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                var response = await _poblacioService.DeletePoblacioAsync(Id);
                if (response.IsSuccessful)
                {
                    await LoadPoblacionsAsync();
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