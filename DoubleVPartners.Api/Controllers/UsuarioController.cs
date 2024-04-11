using DoubleVPartners.Application.DTO.Request;
using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Services;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoubleVPartners.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicesAdapter _usuarioServicesAdapter;

        public UsuarioController(IUsuarioServicesAdapter usuarioServicesAdapter)
        {
            this._usuarioServicesAdapter = usuarioServicesAdapter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personaRequest"></param>
        /// <returns></returns>
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioRequestDTO personaRequest)
        {
            try
            {
                await _usuarioServicesAdapter.CreateUsuario(personaRequest);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (DomainValidateException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseError
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"Errors: {ex.Message}"
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
        /// 
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
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
                    Message = $"Errors: {ex.Message}"
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
    }
}
