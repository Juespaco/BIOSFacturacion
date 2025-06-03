using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Response;
using GrupoBIOS.Services.API.Helpers;
using GrupoBIOS.Transversal.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace GrupoBIOS.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SiesaController : ControllerBase
    {
        private readonly IConfiguration _config;
        //private readonly HttpClient _httpClient;
        private readonly ApiSiesa _appSiesaSettings;

        private readonly IHttpClientFactory _httpClientFactory;

        public SiesaController(IConfiguration config, IOptions<ApiSiesa> appSiesaSettings, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _appSiesaSettings = appSiesaSettings.Value;            
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetListCompaniaAsync")]
        public async Task<IActionResult> GetListCompaniaAsync()
        {
            var parameters = new Dictionary<string, string>
            {
                ["idCompania"] = _appSiesaSettings.IdCompania.ToString()
            };

            var url = ApiUrlBuilder.BuildUrl(_appSiesaSettings.Companias!, parameters);

            var client = _httpClientFactory.CreateClient("SiesaClient");

            ResponseSiesa<IEnumerable<CompaniaSiesaResponseDTO>> response = new();
            Response<IEnumerable<CompaniaSiesaResponseDTO>> result = new();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var resp = await client.SendAsync(request);

                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadFromJsonAsync<ResponseSiesa<IEnumerable<CompaniaSiesaResponseDTO>>?>()
                                    ?? new ResponseSiesa<IEnumerable<CompaniaSiesaResponseDTO>>
                                    {
                                        codigo = 0,
                                        mensaje = "La respuesta no contenía datos válidos"
                                    };

                    result.IsSuccess = true;
                    result.Data = response!.detalle!.Table;
                    result.Message = response.mensaje;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Data = null;
                    result.Message = $"Error: {resp.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Data = null;
                result.Message = $"Error: {ex.Message}";
            }

            return Ok(result);
        }

        [HttpGet("GetListCentrosOperativosAsync")]
        public async Task<IActionResult> GetListCentrosOperativosAsync(int p_cia)
        {
            var parameters = new Dictionary<string, string>
            {
                ["idCompania"] = _appSiesaSettings.IdCompania.ToString(),
                ["p_cia"] = p_cia.ToString()
            };

            var url = ApiUrlBuilder.BuildUrl(_appSiesaSettings.CentrodeOperaciones!, parameters);

            var client = _httpClientFactory.CreateClient("SiesaClient");

            ResponseSiesa<IEnumerable<CentrosOperativosSiesaResponseDTO>> response = new();
            Response<IEnumerable<CentrosOperativosSiesaResponseDTO>> result = new();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var resp = await client.SendAsync(request);

                if (resp.IsSuccessStatusCode)
                {
                    response = await resp.Content.ReadFromJsonAsync<ResponseSiesa<IEnumerable<CentrosOperativosSiesaResponseDTO>>?>()
                                    ?? new ResponseSiesa<IEnumerable<CentrosOperativosSiesaResponseDTO>>
                                    {
                                        codigo = 0,
                                        mensaje = "La respuesta no contenía datos válidos"
                                    };

                    result.IsSuccess = true;
                    result.Data = response!.detalle!.Table;
                    result.Message = response.mensaje;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Data = null;
                    result.Message = $"Error: {resp.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Data = null;
                result.Message = $"Error: {ex.Message}";
            }

            return Ok(result);
        }
    }
}
