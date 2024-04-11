using DoubleVPartners.Application.DTO.Request;
using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Services;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoubleVPartners.Api.Controllers
{
    /// <summary>
    /// Endpoint para creación y login de usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicesAdapter _usuarioServicesAdapter;

        /// <summary>
        /// Constructor principal
        /// </summary>
        public UsuarioController(IUsuarioServicesAdapter usuarioServicesAdapter)
        {
            this._usuarioServicesAdapter = usuarioServicesAdapter;
        }

        /// <summary>
        /// Se encarga de crear los usuarios para el login.
        /// </summary>
        /// <param name="usuarioRequest">Modelo usado para la creación de lso usuario.</param>
        /// <returns></returns>
        /// <response code="201">Devuelve indicando que fue creado correctamente.</response>
        /// <response code="400">Indica error con los datos o alerta.</response>
        /// <response code="500">Devuelve alguna excepción controlada.</response>
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioRequestDTO usuarioRequest)
        {
            try
            {
                await _usuarioServicesAdapter.CreateUsuario(usuarioRequest);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (DomainValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Se presento un error al registrar la persona." + ex.Message
                });
            }
        }

        /// <summary>
        /// Se encarga de validar el login de los usuarios registrados.
        /// </summary>
        /// <param name="loginDTO">Modelo que recibe el usuario y contraseña para ser validados.</param>
        /// <returns></returns>
        /// <response code="200">Devuelve indicando que fue correcto el logueo.</response>
        /// <response code="400">Indica error con los datos o alerta.</response>
        /// <response code="500">Devuelve alguna excepción controlada.</response>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                await _usuarioServicesAdapter.Login(loginDTO);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (DomainValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseError
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Se presento un error al loguearse." + ex.Message
                });
            }
        }
    }
}
