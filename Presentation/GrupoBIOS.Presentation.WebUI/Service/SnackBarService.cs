

using MudBlazor;

namespace GrupoBIOS.Presentation.WebUI.Service
{
    public class SnackBarService : IDisposable
    {
        private readonly ISnackbar _snackbar;
        private bool _disposed;

        public SnackBarService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
            ConfigureDefaultOptions();
        }

        private void ConfigureDefaultOptions()
        {
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopEnd;
            _snackbar.Configuration.SnackbarVariant = Variant.Filled;
            _snackbar.Configuration.MaxDisplayedSnackbars = 5;
        }

        public void ShowSnackBar(string message, Severity severity, string? positionClass = null)
        {
            if (_disposed) return;

            _snackbar.Clear();

            if (!string.IsNullOrWhiteSpace(positionClass))
            {
                _snackbar.Configuration.PositionClass = positionClass;
            }

            _snackbar.Add(message, severity);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _snackbar.Clear();
                _disposed = true;
            }
        }
    }
}
