using DoubleVPartners.Domain.IRepository;
using DoubleVPartners.Domain.Model;
using DoubleVPartners.Infrastructure.Entities;
using DoubleVPartners.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Infrastructure.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PartnersDbContext _dBContext;
        public PersonaRepository(PartnersDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<PersonaModel> CreatePersonAsync(PersonaModel personaModel)
        {
            var entity = personaModel.MapToEntity<PersonaEntity>();
            _dBContext.Set<PersonaEntity>().Add(entity);
            await _dBContext.SaveChangesAsync();

            return entity.MapToEntity<PersonaModel>();
        }

        public async Task<List<PersonaModel>> ListPersonAsync()
        {
            return (await _dBContext.Personas.Include(p=> p.tipoIdentificacion).ToListAsync()).MapToEntity<List<PersonaModel>>();
        }

        public async Task<bool> ValidatePersonAsync(string Identificacion)
        {
            var estado = await _dBContext.Personas.Where(p => p.Identificacion == Identificacion).FirstOrDefaultAsync() == null;
            return estado;
        }
    }
}
