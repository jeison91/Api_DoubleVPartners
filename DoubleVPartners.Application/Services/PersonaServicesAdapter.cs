using DoubleVPartners.Application.DTO.Request;
using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Mapper;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.IServices;
using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.Services
{
    public class PersonaServicesAdapter : IPersonaServicesAdapter
    {
        private readonly IPersonaServicesPort _personaServicesPort;

        public PersonaServicesAdapter(IPersonaServicesPort personaServicesPort)
        {
            this._personaServicesPort = personaServicesPort;
        }

        public async Task CreatePerson(PersonaRequestDTO personaRequest)
        {
            var personaModel = personaRequest.MapToModel<PersonaModel>();
            await _personaServicesPort.CreatePerson(personaModel);
        }

        public async Task<List<PersonaResponseDTO>> ListPerson()
        {
            var model = await _personaServicesPort.ListPerson();
            var responseDTOs = PersonaMapper.MapDTOList(model);
            return responseDTOs;
        }
    }
}
