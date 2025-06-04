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
    public class PncApplication : IPncApplication
    {
        private readonly IPncDomain _domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PncApplication> _logger;

        public PncApplication(IPncDomain domain, IMapper mapper, IAppLogger<PncApplication> logger)
        {
            _domain = domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> CrearActualizarPncsAsync(IEnumerable<PncDTO> pncsDto)
        {
            var response = new Response<string>();

            try
            {
                var entities = _mapper.Map<IEnumerable<Pnc>>(pncsDto);
                var result = await _domain.CrearActualizarPncsAsync(entities);

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
