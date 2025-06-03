using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Application.DTOs.Response.Auth;
using GrupoBIOS.Application.Interface;
using GrupoBIOS.Application.Interface.Service;
using GrupoBIOS.Application.Main;
using GrupoBIOS.Transversal.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GrupoBIOS.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioApplication _Application;
        private readonly ITokenService _tokenService;

        private static readonly HttpClient client = new HttpClient();
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAppLogger<UsuarioApplication> _logger;


        public UsuarioController(
            IUsuarioApplication _Application,
            IOptions<AppSettings> appSettings,
            IConfiguration config,
            IWebHostEnvironment hostingEnvironment,
            IAppLogger<UsuarioApplication> logger,
            ITokenService tokenService)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<UsuarioDTO>> response = new Response<IEnumerable<UsuarioDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync(int IDUsuario)
        {
            Response<UsuarioDTO> response = new Response<UsuarioDTO>();

            try
            {
                response = await _Application.GetAsync(IDUsuario);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario(UsuarioDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (model == null)
                    return BadRequest();
                
                response = await this._Application.InsertAsync(model);

                if (response.IsSuccess)
                {
                    
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;
                
                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpPost("ActualizarUsuario")]
        public async Task<IActionResult> ActualizarUsuario(UsuarioDTO model)
        {
            Response<string> response = new Response<string>();
            //Validación del cambio de la contraseña
            if (!model.IsUpdatePassword)
            {
                model.Contrasena = string.Empty;
                model.ConfirmarContrasena = string.Empty;
            }

            try
            {
                if (model == null)
                    return BadRequest();

                response = await this._Application.UpdateAsync(model);

                if (response.IsSuccess)
                {

                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = string.Empty;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDTO model)
        {
            Response<LoginResponseDTO> response = new Response<LoginResponseDTO>();

            try
            {
                if (model == null)
                    return BadRequest();

                var usuarioResponse = await this._Application.GetLogin(model);

                if (usuarioResponse.IsSuccess && usuarioResponse.Data != null)
                {
                    // Generar token
                    var token = _tokenService.GenerateToken(usuarioResponse.Data);

                    // Crear respuesta con token
                    var loginResponse = new LoginResponseDTO
                    {
                        Usuario = usuarioResponse.Data,
                        Token = token,
                        ExpiraEn = DateTime.UtcNow.AddHours(2) // Coincide con la expiración del token
                    };

                    response.Data = loginResponse;
                    response.IsSuccess = true;
                    response.Message = "Autenticación exitosa";

                    return Ok(response);
                }
                else
                {
                    return Unauthorized(usuarioResponse);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return StatusCode(500, response);
            }
        }

        [HttpDelete("DesactivarUsuarioAsync")]
        public async Task<IActionResult> DesactivarUsuarioAsync(int IDUsuario)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response = await _Application.DesactivarUsuario(IDUsuario);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message);

                return BadRequest(response);
            }
        }

    }
}
