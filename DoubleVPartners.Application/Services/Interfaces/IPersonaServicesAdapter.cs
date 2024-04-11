using DoubleVPartners.Application.DTO.Request;
using DoubleVPartners.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.Services.Interfaces
{
    public interface IPersonaServicesAdapter
    {
        Task CreatePerson(PersonaRequestDTO personaRequest);
        Task<List<PersonaResponseDTO>> ListPerson();
    }
}
