using AutoMapper;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Main
{
    public class ExcepcionApplication : IExcepcionApplication
    {
        private readonly IExcepcionDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ExcepcionApplication> _logger;

        public ExcepcionApplication(IExcepcionDomain _Domain, IMapper mapper, IAppLogger<ExcepcionApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<Response<string>> CrearActualizarExcepcionesAsync(IEnumerable<ExcepcionDTO> modelDtos)
        {
            var response = new Response<string>();
            try
            {
                var listaExcepciones = _mapper.Map<IEnumerable<Excepcion>>(modelDtos);

                response.Data = await _Domain.CrearActualizarExcepcionesAsync(listaExcepciones);

                if (response.Data == "OK")
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = response.Data;
                    response.Data = string.Empty;

                    _logger.LogWarning(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);
            }

            return response;
        }

    }
}
