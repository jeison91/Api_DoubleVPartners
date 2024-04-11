using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Services;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoubleVPartners.Api.Controllers
{
    /// <summary>
    /// Endpoint de los tipos de identificación.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly ITipoIdentificacionServicesAdapter _tipoIdentificacionServicesAdapter;

        /// <summary>
        /// Constructor principal
        /// </summary>
        public TipoIdentificacionController(ITipoIdentificacionServicesAdapter tipoIdentificacionServicesAdapter)
        {
            this._tipoIdentificacionServicesAdapter = tipoIdentificacionServicesAdapter;
        }

        /// <summary>
        /// Se encarga de listar todos los tipos de identificación.
        /// </summary>
        /// <returns>Retorna una lista de los tipos de identificación.</returns>
        /// <response code="200">Devuelve indicando que cargaron correctamente.</response>
        /// <response code="400">Indica error con los datos o alerta.</response>
        /// <response code="500">Devuelve alguna excepción controlada.</response>
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
                    Message = ex.Message
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
