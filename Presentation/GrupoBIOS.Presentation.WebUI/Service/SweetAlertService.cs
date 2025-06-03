using Microsoft.JSInterop;

namespace GrupoBIOS.Presentation.WebUI.Service
{
    public class SweetAlertService
    {
        private readonly IJSRuntime _jsRuntime;

        public SweetAlertService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowSuccessAsync(string message, string title = "Éxito")
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", title, message, "success");
        }

        public async Task ShowErrorAsync(string message, string title = "Error")
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", title, message, "error");
        }

        public async Task ShowWarningAsync(string message, string title = "Advertencia")
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", title, message, "warning");
        }

        public async Task ShowInfoAsync(string message, string title = "Información")
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", title, message, "info");
        }

        public async Task<bool> ShowConfirmAsync(string message, string title = "Confirmación")
        {
            var options = new
            {
                title = title,
                text = message,
                icon = "question",
                showCancelButton = true,
                confirmButtonText = "Sí",
                cancelButtonText = "No"
            };

            return await _jsRuntime.InvokeAsync<bool>("Swal.fire", options);
        }

        public async Task ShowCustomAsync(string title, string message, string icon)
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", title, message, icon);
        }
    }
}
