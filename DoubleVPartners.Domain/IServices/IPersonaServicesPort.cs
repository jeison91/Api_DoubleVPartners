using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Domain.IServices
{
    public interface IPersonaServicesPort
    {
        Task<PersonaModel> CreatePerson(PersonaModel personaModel);
        Task<List<PersonaModel>> ListPerson();
    }
}
