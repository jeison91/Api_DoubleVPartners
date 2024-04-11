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
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly ITipoIdentificacionServicesAdapter _tipoIdentificacionServicesAdapter;

        public TipoIdentificacionController(ITipoIdentificacionServicesAdapter tipoIdentificacionServicesAdapter)
        {
            this._tipoIdentificacionServicesAdapter = tipoIdentificacionServicesAdapter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                return Ok(await _tipoIdentificacionServicesAdapter.List());
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
                    Message = "Se presento un error al listar los tipos de identificación." + ex.Message
                });
            }
        }
    }
}
