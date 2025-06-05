using AutoMapper;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Main
{
    public class CentroOperativoApplication : ICentroOperativoApplication
    {
        private readonly ICentroOperativoDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CentroOperativoApplication> _logger;

        public CentroOperativoApplication(ICentroOperativoDomain _Domain, IMapper mapper, IAppLogger<CentroOperativoApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> DeleteAsync(int ID)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DeleteAsync(ID);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<bool>> DesactivarCentroOperativo(int IDCentroOperativo)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DesactivarCentroOperativo(IDCentroOperativo);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<CentroOperativoDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CentroOperativoDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CentroOperativoDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<CentroOperativoDTO>> GetAsync(int ID)
        {
            var response = new Response<CentroOperativoDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);
                response.Data = _mapper.Map<CentroOperativoDTO>(result);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> InsertAsync(CentroOperativoDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<CentroOperativo>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);

                if (response.Data == "OK")
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
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

        public async Task<Response<string>> UpdateAsync(CentroOperativoDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<CentroOperativo>(modelDto);
                response.Data = await _Domain.UpdateAsync(resp);

                if (response.Data == "OK")
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
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

        public async Task<Response<string>> CrearActualizarCentroOperativoAsync(IEnumerable<CentroOperativoDTO> centroOperativoDto)
        {
            var response = new Response<string>();

            try 
            {
                foreach (var centro in centroOperativoDto)
                {
                    if (!string.IsNullOrWhiteSpace(centro.CorreoEnvioReporte))
                    {
                        var correos = centro.CorreoEnvioReporte.Split(',')
                            .Select(c => c.Trim())
                            .Where(c => !string.IsNullOrWhiteSpace(c));

                        foreach (var correo in correos)
                        {
                            if (!EsCorreoValido(correo))
                            {
                                response.IsSuccess = false;
                                response.Data = string.Empty;
                                response.Message = $"El correo '{correo}' no tiene un formato válido.";
                                return response;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Data = string.Empty;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            try
            {
                var entities = _mapper.Map<IEnumerable<CentroOperativo>>(centroOperativoDto);
                var result = await _Domain.CrearActualizarCentroOperativoAsync(entities);

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

        private bool EsCorreoValido(string correo)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(correo);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
