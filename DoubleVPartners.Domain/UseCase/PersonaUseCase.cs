using DoubleVPartners.Domain.Exceptions;
using DoubleVPartners.Domain.IRepository;
using DoubleVPartners.Domain.IServices;
using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Domain.UseCase
{
    public class PersonaUseCase : IPersonaServicesPort
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaUseCase(IPersonaRepository personaRepository)
        {
            this._personaRepository = personaRepository;
        }

        public async Task<PersonaModel> CreatePerson(PersonaModel personaModel)
        {
            //Validar si la existe la persona con el mismo identificador
            if (!await _personaRepository.ValidatePersonAsync(personaModel.Identificacion))
                throw new DomainValidateException("Una persona con esta identificación ya está registrada.");

            //Registar persona
            var responsePersonaModel = await _personaRepository.CreatePersonAsync(personaModel);
            return responsePersonaModel;
        }

        public async Task<List<PersonaModel>> ListPerson()
        {
            return await _personaRepository.ListPersonAsync();
        }
    }
}
