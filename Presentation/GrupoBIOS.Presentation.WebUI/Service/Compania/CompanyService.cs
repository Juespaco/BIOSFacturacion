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
using System.Text;
using System.Text.Json;

namespace GrupoBIOS.Presentation.WebUI.Service.Compania
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<Response<bool>> DesactivarCompania(int IDCompania)
        //{
        //    Response<bool> respData = new Response<bool>();

        //    try
        //    {
        //        var response = await _httpClient.DeleteAsync($"api/Compania/DesactivarCompaniaAsync?IDCompania={IDCompania}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            respData = await response.Content.ReadFromJsonAsync<Response<bool>?>()
        //                        ?? new Response<bool>
        //                        {
        //                            IsSuccess = false,
        //                            Message = "La respuesta no contenía datos válidos"
        //                        };
        //        }
        //        else
        //        {
        //            respData.IsSuccess = false;
        //            respData.Message = $"Error: {response.StatusCode}";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        respData.IsSuccess = false;
        //        respData.Message = $"Error: {ex.Message}";
        //    }

        //    return respData;
        //}

        public async Task<Response<CompaniaDTO>> GetCompaniaId(int IDCompania)
        {
            Response<CompaniaDTO> respData = new Response<CompaniaDTO>();

            try
            {
                var response = await _httpClient.GetAsync($"api/Compania/GetAsync?IDCompania={IDCompania}");

                if (response.IsSuccessStatusCode)
                {
                    respData = await response.Content.ReadFromJsonAsync<Response<CompaniaDTO>?>()
                                ?? new Response<CompaniaDTO>
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

        public async Task<Response<ConfiguracionCompaniaDTO>> GetConfiguracionCompaniaId(int IDCompania)
        {
            Response<ConfiguracionCompaniaDTO> respData = new Response<ConfiguracionCompaniaDTO>();

            try
            {
                var response = await _httpClient.GetAsync($"api/Compania/ObtenerConfiguracionCompaniaPorIDSiesa?IDSiesa={IDCompania}");

                if (response.IsSuccessStatusCode)
                {
                    respData = await response.Content.ReadFromJsonAsync<Response<ConfiguracionCompaniaDTO>?>()
                                ?? new Response<ConfiguracionCompaniaDTO>
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
        public async Task<Response<IEnumerable<CompaniaDTO>>> GetListCompanias()
        {
            Response<IEnumerable<CompaniaDTO>> respData = new Response<IEnumerable<CompaniaDTO>>();

            try
            {
                var response = await _httpClient.GetAsync("api/Compania/GetAllAsync");

                if (response.IsSuccessStatusCode)
                {
                    respData = await response.Content.ReadFromJsonAsync<Response<IEnumerable<CompaniaDTO>>?>()
                                ?? new Response<IEnumerable<CompaniaDTO>>
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

        //public async Task<string> Register(CompaniaDTO register)
        //{
        //    Response<string>? request = new Response<string>();

        //    var registerAsJson = JsonSerializer.Serialize(register);

        //    var response = await _httpClient.PostAsync("api/Compania/CrearCompaniaAsync",
        //        new StringContent(registerAsJson, Encoding.UTF8, "application/json"));            

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return "Ha ocurrido un error mientras se creaba el registro."!;
        //    }

        //    var registerResult = await response.Content.ReadAsStringAsync();
        //    request = JsonSerializer.Deserialize<Response<string>>(registerResult);
        //    if (request!.IsSuccess!)
        //    {
        //        return "OK";
        //    }
        //    else
        //    {
        //        return request!.Message!;
        //    }
        //}

        //public async Task<string?> UpdateCompaniaAsync(CompaniaDTO register)
        //{
        //    Response<string>? request = new Response<string>();

        //    var registerAsJson = JsonSerializer.Serialize(register);

        //    var response = await _httpClient.PostAsync("api/Compania/ActualizarCompaniaAsync",
        //        new StringContent(registerAsJson, Encoding.UTF8, "application/json"));

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return "Ha ocurrido un error mientras se actualizaba el registro."!;
        //    }

        //    var registerResult = await response.Content.ReadAsStringAsync();
        //    request = JsonSerializer.Deserialize<Response<string>>(registerResult);
        //    if (request!.IsSuccess!)
        //    {
        //        return "OK";
        //    }
        //    else
        //    {
        //        return request!.Message!;
        //    }
        //}

        public async Task<string> ConfigurarCompania(ConfiguracionCompaniaDTO model)
        {
            Response<string>? request = new Response<string>();

            var registerAsJson = JsonSerializer.Serialize(model);

            var response = await _httpClient.PostAsync("api/Compania/CrearActualizarConfiguracionCompaniaAsync",
                new StringContent(registerAsJson, Encoding.UTF8, "application/json"));

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
        }
    }
}
