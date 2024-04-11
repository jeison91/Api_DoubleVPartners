using DoubleVPartners.Application.DTO.Request;
using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoubleVPartners.Api.Controllers
{
    /// <summary>
    /// Endpoint para creación y consulta de personas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServicesAdapter _personaServicesAdapter;

        /// <summary>
        /// Construir principal
        /// </summary>
        public PersonaController(IPersonaServicesAdapter personaServicesAdapter)
        {
            this._personaServicesAdapter = personaServicesAdapter;
        }

        /// <summary>
        /// Se encarga de crear las personas.
        /// </summary>
        /// <param name="personaRequest">Modelo usado para la creación de la persona</param>
        /// <returns></returns>
        /// <response code="201">Devuelve indicando que fue creado correctamente.</response>
        /// <response code="400">Indica error con los datos o alerta.</response>
        /// <response code="500">Devuelve alguna excepción controlada.</response>
        [HttpPost("CrearPersona")]
        public async Task<IActionResult> CrearPersona([FromBody] PersonaRequestDTO personaRequest)
        {
            try
            {
                await _personaServicesAdapter.CreatePerson(personaRequest);
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
        /// Se encarga de buscar y listar todos las personas.
        /// </summary>
        /// <returns>Modelo con la lista de personas creadas.</returns>
        /// <response code="200">Indica que se devolvió correctamente la lista.</response>
        /// <response code="400">Indica error con los datos o alerta.</response>
        /// <response code="500">Devuelve alguna excepción controlada.</response>
        [HttpGet("ListarPersona")]
        public async Task<IActionResult> ListarPersona()
        {
            try
            {
                return Ok(await _personaServicesAdapter.ListPerson());
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
                    Message = "Se presento un error al listar las personas." + ex.Message
                });
            }
        }
    }
}
