using Blazored.LocalStorage;
using GrupoBIOS.Presentation.WebUI;
using GrupoBIOS.Presentation.WebUI.Model;
using GrupoBIOS.Presentation.WebUI.Provider;
using GrupoBIOS.Presentation.WebUI.Service;
using GrupoBIOS.Presentation.WebUI.Service.Auth;
using GrupoBIOS.Presentation.WebUI.Service.Compania;
using GrupoBIOS.Presentation.WebUI.Service.Excepcion;
using GrupoBIOS.Presentation.WebUI.Service.ShowDialog;
using GrupoBIOS.Presentation.WebUI.Service.Siesa;
using GrupoBIOS.Transversal.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
    provider => provider.GetRequiredService<ApiAuthenticationStateProvider>()
);

//builder.Services.AddMudServices();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IExcepcionService, ExcepcionService>();
builder.Services.AddScoped<ISiesaService, SiesaService>();

builder.Services.AddScoped<SweetAlertService>();
builder.Services.AddScoped<LoadingDialogService>();
builder.Services.AddScoped<SnackBarService>();
builder.Services.AddScoped<ShowDialogService>();
// Registra el servicio Cifrador (dependiendo de su tipo de ciclo de vida)
builder.Services.AddScoped<Cifrador>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var urlBaseApi = builder.Configuration.GetValue<string>("BaseUrl");
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(urlBaseApi!) });

await builder.Build().RunAsync();
