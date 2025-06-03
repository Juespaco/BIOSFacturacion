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
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UsuarioApplication> _logger;

        public UsuarioApplication(IUsuarioDomain _Domain, IMapper mapper, IAppLogger<UsuarioApplication> logger)
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

        public async Task<Response<bool>> DesactivarUsuario(int IDUsuario)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DesactivarUsuario(IDUsuario);
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

        public async Task<Response<IEnumerable<UsuarioDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UsuarioDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<UsuarioDTO>>(resp);
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

        public async Task<Response<UsuarioDTO>> GetAsync(int ID)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);
                response.Data = _mapper.Map<UsuarioDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<UsuarioDTO>> GetLogin(LoginRequestDTO login)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var resp = _mapper.Map<LoginRequest>(login);
                var result = await _Domain.GetLogin(resp);
                response.Data = _mapper.Map<UsuarioDTO>(result);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> InsertAsync(UsuarioDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Usuario>(modelDto);
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

        public async Task<Response<string>> UpdateAsync(UsuarioDTO modelDto)
        {
            var response = new Response<string>();
            try
            {
                var resp = _mapper.Map<Usuario>(modelDto);
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
    }
}
