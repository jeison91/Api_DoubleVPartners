using DoubleVPartners.Domain.IRepository;
using DoubleVPartners.Domain.Model;
using DoubleVPartners.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Infrastructure.Repository
{
    public class TipoIdentificacionRepository : ITipoIdentificacionRepository
    {
        private readonly PartnersDbContext _dBContext;
        public TipoIdentificacionRepository(PartnersDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<TipoIdentificacionModel>> GetList()
        {
            var sectors = (await _dBContext.TipoIdentificaciones.ToListAsync()).MapToEntity<List<TipoIdentificacionModel>>();
            return sectors;
        }
    }
}
