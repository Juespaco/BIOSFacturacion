using AutoMapper;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Main
{
    public class ClaseApplication : IClaseApplication
    {
        private readonly IClaseDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ClaseApplication> _logger;

        public ClaseApplication(IClaseDomain _Domain, IMapper mapper, IAppLogger<ClaseApplication> logger)
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

        public async Task<Response<IEnumerable<ClaseDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ClaseDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<ClaseDTO>>(resp);
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

        public async Task<Response<ClaseDTO>> GetAsync(int ID)
        {
            var response = new Response<ClaseDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);
                response.Data = _mapper.Map<ClaseDTO>(result);
                
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                response.Data = null;

                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> InsertAsync(ClaseDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Clase>(modelDto);
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

        public async Task<Response<string>> UpdateAsync(ClaseDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Clase>(modelDto);
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
        public async Task<Response<string>> DesactivarClase(int IDClase)
        {
            var response = new Response<string>();
            try
            {
                response.Data = await _Domain.DesactivarClase(IDClase);

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
    }
}
