using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Transversal.Common;
using System.Text;
using System.Text.Json;

namespace GrupoBIOS.Presentation.WebUI.Service.Excepcion
{
    public class ExcepcionService : IExcepcionService
    {
        private readonly HttpClient _httpClient;

        public ExcepcionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> Register(List<ExcepcionDTO> register)
        {
            Response<string>? request = new Response<string>();

            var registerAsJson = JsonSerializer.Serialize(register);

            var response = await _httpClient.PostAsync("api/Excepcion/CrearActualizarExcepcionesAsync",
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
