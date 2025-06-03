using GrupoBIOS.Presentation.WebUI.Service.ShowDialog;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GrupoBIOS.Presentation.WebUI.Service
{
    public class ShowDialogService : IDisposable
    {
        private readonly IDialogService _dialogService;
        private bool _disposed;

        public ShowDialogService(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        public Task<IDialogReference> ShowDialogAsync<TComponent>(
            string? title,
            DialogOptions options = null,
            DialogParameters parameters = null) where TComponent : ComponentBase
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(ShowDialogService));

            options ??= new DialogOptions
            {
                CloseOnEscapeKey = true,
                CloseButton = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true,
                BackdropClick = true,
                NoHeader = false
            };

            return _dialogService.ShowAsync<TComponent>(title, parameters ?? new DialogParameters(), options);
        }

        public Task<bool?> ShowMessageBoxAsync(
            string? title,
            string message,
            string yesText = "OK",
            string noText = null,
            string cancelText = null)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(ShowDialogService));

            return _dialogService.ShowMessageBox(title, message, yesText, noText, cancelText);
        }

        public async Task<bool?> ShowDangerConfirmationAsync(
            string? title,
            string message,
            string confirmText = "Eliminar",
            string cancelText = "Cancelar")
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(ShowDialogService));

            var dialogReference = await _dialogService.ShowAsync<DangerMessageBox>(
                title, // Este es el título que aparece en la barra del diálogo
                new DialogParameters
                {
                    { "Message", message },
                    { "ConfirmText", confirmText },
                    { "CancelText", cancelText }
                },
                new DialogOptions { CloseButton = true, NoHeader = false });

            var result = await dialogReference.Result;

            return result.Canceled ? null : (bool?)result.Data;
        }

        public Task ShowSuccessMessageAsync(string? title, string message)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(ShowDialogService));

            return ShowDialogAsync<SuccessMessageBox>(
                title: string.Empty,
                parameters: new DialogParameters
                {
                    { "Title", title },
                    { "Message", message }
                },
                options: new DialogOptions { CloseButton = false, NoHeader = false });
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}