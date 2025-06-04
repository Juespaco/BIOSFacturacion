using AutoMapper;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Main
{
    public class NivelApplication : INivelApplication
    {
        private readonly INivelDomain _domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<NivelApplication> _logger;

        public NivelApplication(INivelDomain domain, IMapper mapper, IAppLogger<NivelApplication> logger)
        {
            _domain = domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> CrearActualizarNivelesAsync(IEnumerable<NivelDTO> nivelesDto)
        {
            var response = new Response<string>();

            try
            {
                var entities = _mapper.Map<IEnumerable<Nivel>>(nivelesDto);
                var result = await _domain.CrearActualizarNivelesAsync(entities);

                response.Data = result;
                response.IsSuccess = result == "OK";
                response.Message = result == "OK" ? "Registro exitoso!" : result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Data = string.Empty;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }
    }

}
