using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Domain.IRepository
{
    public interface IPersonaRepository
    {
        Task<PersonaModel> CreatePersonAsync(PersonaModel personaModel);
        Task<List<PersonaModel>> ListPersonAsync();
        Task<bool> ValidatePersonAsync(string Identificacion);
    }
}
