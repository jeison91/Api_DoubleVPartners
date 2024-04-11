using DoubleVPartners.Application.DTO.Request;
using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoubleVPartners.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServicesAdapter _personaServicesAdapter;

        public PersonaController(IPersonaServicesAdapter personaServicesAdapter)
        {
            this._personaServicesAdapter = personaServicesAdapter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personaRequest"></param>
        /// <returns></returns>
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
                    Message = $"Error: {ex.Message}"
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
        /// <returns></returns>
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
                    Message = $"Error: {ex.Message}"
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
