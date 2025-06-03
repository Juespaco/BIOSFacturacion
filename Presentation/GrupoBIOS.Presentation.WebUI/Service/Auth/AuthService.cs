using Blazored.LocalStorage;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Application.DTOs.Response.Auth;
using GrupoBIOS.Presentation.WebUI.Pages.Auth;
using GrupoBIOS.Presentation.WebUI.Provider;
using GrupoBIOS.Transversal.Common;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace GrupoBIOS.Presentation.WebUI.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<Response<LoginResponseDTO>> Login(LoginRequestDTO login)
        {
            var response = new Response<LoginResponseDTO>();

            try
            {
                var result = await _httpClient.PostAsJsonAsync("api/Usuario/login", login);

                if (result.IsSuccessStatusCode)
                {
                    // Deserialización automática a Response<LoginResponseDTO>
                    response = await result.Content.ReadFromJsonAsync<Response<LoginResponseDTO>>();                    
                }
                else
                {
                    // Manejo de errores HTTP
                    response.IsSuccess = false;
                    response.Message = $"Error: {result.StatusCode}";

                    // Opcional: Leer el mensaje de error del cuerpo si existe
                    var errorContent = await result.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(errorContent))
                    {
                        try
                        {
                            var errorResponse = JsonSerializer.Deserialize<Response<LoginResponseDTO>>(errorContent);
                            response.Message = errorResponse?.Message ?? response.Message;
                        }
                        catch
                        {
                            response.Message = errorContent;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response!.IsSuccess = false;
                response.Message = $"Error inesperado: {ex.Message}";
            }

            return response!;
        }        
        public async Task AuthProvider(string NombredeUsuario, string Token, string CompaniaIdSel, string CentroOperativo)
        {
            await _localStorage.SetItemAsStringAsync("authToken", Token);
            await _localStorage.SetItemAsStringAsync("IdCompania", CompaniaIdSel);
            await _localStorage.SetItemAsStringAsync("CentroOperativo", CentroOperativo);

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(NombredeUsuario, CompaniaIdSel);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("IdCompania");
            await _localStorage.RemoveItemAsync("CentroOperativo");

            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string> Register(UsuarioDTO register)
        {
            Response<string>? request = new Response<string>();

            var registerAsJson = JsonSerializer.Serialize(register);

            var response = await _httpClient.PostAsync("api/Usuario/CrearUsuario",
                new StringContent(registerAsJson, Encoding.UTF8, "application/json"));

            //response = await result.Content.ReadFromJsonAsync<Response<LoginResponseDTO>>();

            if (!response.IsSuccessStatusCode)
            {
                return "Ha ocurrido un error mientras se creaba el registro."!;
            }

            var registerResult = await response.Content.ReadAsStringAsync();
            request = JsonSerializer.Deserialize<Response<string>>(registerResult);
            if (request!.IsSuccess!)
            {
                return "OK";
            }
            else
            {
                return request!.Message!;
            }
            //var registerResult = await response.Content.ReadFromJsonAsync<Response<string>>();

            //return registerResult;
        }

        public async Task<string?> UpdateUserAsync(UsuarioDTO register)
        {
            Response<string>? request = new Response<string>();

            var registerAsJson = JsonSerializer.Serialize(register);

            var response = await _httpClient.PostAsync("api/Usuario/ActualizarUsuario",
                new StringContent(registerAsJson, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                return "Ha ocurrido un error mientras se actualizaba el registro."!;
            }

            var registerResult = await response.Content.ReadAsStringAsync();
            request = JsonSerializer.Deserialize<Response<string>>(registerResult);
            if (request!.IsSuccess!)
            {
                return "OK";
            }
            else
            {
                return request!.Message!;
            }
        }

        public async Task<string?> GetUserNameAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return user.FindFirst("unique_name")?.Value;
        }

        public async Task<string?> GetNameAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return user.FindFirst("Nombre")?.Value;
        }

        public async Task<string?> GetUserRoleAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return user.FindFirst("NombreRol")?.Value;
            //return user.FindFirst(ClaimTypes.Role)?.Value;
        }

        public async Task<Response<IEnumerable<UsuarioDTO>>> GetListUsers()
        {
            Response<IEnumerable<UsuarioDTO>> respData = new Response<IEnumerable<UsuarioDTO>>();

            try
            {
                var response = await _httpClient.GetAsync("api/Usuario/GetAllAsync");

                if (response.IsSuccessStatusCode)
                {                    
                    respData = await response.Content.ReadFromJsonAsync<Response<IEnumerable<UsuarioDTO>>?>()
                                ?? new Response<IEnumerable<UsuarioDTO>>
                                {
                                    IsSuccess = false,
                                    Message = "La respuesta no contenía datos válidos"
                                };                    
                }
                else
                {
                    respData.IsSuccess = false;
                    respData.Message = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                respData.IsSuccess = false;
                respData.Message = $"Error: {ex.Message}";                
            }

            return respData;
        }

        public async Task<Response<UsuarioDTO>> GetUserId(int IDUsuario)
        {
            Response<UsuarioDTO> respData = new Response<UsuarioDTO>();

            try
            {
                var response = await _httpClient.GetAsync($"api/Usuario/GetAsync?IDUsuario={IDUsuario}");

                if (response.IsSuccessStatusCode)
                {
                    respData = await response.Content.ReadFromJsonAsync<Response<UsuarioDTO>?>()
                                ?? new Response<UsuarioDTO>
                                {
                                    IsSuccess = false,
                                    Message = "La respuesta no contenía datos válidos"
                                };
                }
                else
                {
                    respData.IsSuccess = false;
                    respData.Message = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                respData.IsSuccess = false;
                respData.Message = $"Error: {ex.Message}";
            }

            return respData;
        }

        public async Task<Response<bool>> DesactivarUsuario(int IDUsuario)
        {
            Response<bool> respData = new Response<bool>();

            try
            {
                var response = await _httpClient.DeleteAsync($"api/Usuario/DesactivarUsuarioAsync?IDUsuario={IDUsuario}");

                if (response.IsSuccessStatusCode)
                {
                    respData = await response.Content.ReadFromJsonAsync<Response<bool>?>()
                                ?? new Response<bool>
                                {
                                    IsSuccess = false,
                                    Message = "La respuesta no contenía datos válidos"
                                };
                }
                else
                {
                    respData.IsSuccess = false;
                    respData.Message = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                respData.IsSuccess = false;
                respData.Message = $"Error: {ex.Message}";
            }

            return respData;
        }
    }
}
