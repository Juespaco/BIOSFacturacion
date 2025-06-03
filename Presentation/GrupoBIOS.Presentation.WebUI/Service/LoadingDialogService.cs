using GrupoBIOS.Presentation.WebUI.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;

namespace GrupoBIOS.Presentation.WebUI.Service
{
    public class LoadingDialogService
    {
        private readonly IServiceProvider _serviceProvider;
        private IDialogReference? _dialogReference;

        public LoadingDialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Show()
        {
            var dialogService = _serviceProvider!.GetRequiredService<IDialogService>()!;

            var options = new DialogOptions
            {                
                BackdropClick = true,
                CloseOnEscapeKey = false,     // Deshabilita cerrar con ESC
                NoHeader = true,               // Oculta el encabezado
                FullScreen = true,
                BackgroundClass = "mud-dialog: rgba(0, 0, 0, 0)"
            };

            _dialogReference = dialogService!.Show<LoadingDialog?>("", options);
        }

        public void Hide()
        {
            _dialogReference?.Close();
            _dialogReference = null;
        }
    }
}
