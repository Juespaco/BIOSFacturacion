using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Response;
using GrupoBIOS.Transversal.Common;
using System.Net.Http.Json;

namespace GrupoBIOS.Presentation.WebUI.Service.Siesa
{
    public class SiesaService : ISiesaService
    {
        private readonly HttpClient _httpClient;

        public SiesaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<IEnumerable<CompaniaSiesaResponseDTO>>> GetListCompaniaAsync()
        {
            Response<IEnumerable<CompaniaSiesaResponseDTO>> respData = new();

            try
            {
                var response = await _httpClient.GetAsync($"api/Siesa/GetListCompaniaAsync");
                if (response.IsSuccessStatusCode)
                {
                    respData = await response.Content.ReadFromJsonAsync<Response<IEnumerable<CompaniaSiesaResponseDTO>>?>()
                                ?? new Response<IEnumerable<CompaniaSiesaResponseDTO>>
                                {
                                    IsSuccess = true,
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

        public async Task<Response<IEnumerable<CentrosOperativosSiesaResponseDTO>>> GetListCentrosOperativosAsync(int p_cia)
        {
            Response<IEnumerable<CentrosOperativosSiesaResponseDTO>> respData = new();

            try
            {
                var response = await _httpClient.GetAsync($"api/Siesa/GetListCentrosOperativosAsync?p_cia={p_cia}");
                if (response.IsSuccessStatusCode)
                {
                    respData = await response.Content.ReadFromJsonAsync<Response<IEnumerable<CentrosOperativosSiesaResponseDTO>>?>()
                                ?? new Response<IEnumerable<CentrosOperativosSiesaResponseDTO>>
                                {
                                    IsSuccess = true,
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
