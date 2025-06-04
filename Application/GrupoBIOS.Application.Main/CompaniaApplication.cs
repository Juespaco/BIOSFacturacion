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
    public class CompaniaApplication : ICompaniaApplication
    {
        private readonly ICompaniaDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CompaniaApplication> _logger;

        public CompaniaApplication(ICompaniaDomain _Domain, IMapper mapper, IAppLogger<CompaniaApplication> logger)
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

        public async Task<Response<bool>> DesactivarCompania(int IDCompania)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DesactivarCompania(IDCompania);
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

        public async Task<Response<IEnumerable<CompaniaDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CompaniaDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CompaniaDTO>>(resp);
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

        public async Task<Response<CompaniaDTO>> GetAsync(int ID)
        {
            var response = new Response<CompaniaDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);
                response.Data = _mapper.Map<CompaniaDTO>(result);
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

        public async Task<Response<string>> InsertAsync(CompaniaDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Compania>(modelDto);
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

        public async Task<Response<string>> UpdateAsync(CompaniaDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Compania>(modelDto);
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

        public async Task<Response<ConfiguracionCompaniaDTO>> ObtenerConfiguracionPorIDSiesaAsync(int IDSiesa)
        {
            var response = new Response<ConfiguracionCompaniaDTO>();
            try
            {
                var entity = await _Domain.ObtenerConfiguracionPorIDSiesaAsync(IDSiesa);
                response.Data = _mapper.Map<ConfiguracionCompaniaDTO>(entity);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

    }
}
