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
    public class TipoIdentificacionUseCase : ITipoIdentificacionServicesPort
    {
        private readonly ITipoIdentificacionRepository _tipoIdentificacionRepository;

        public TipoIdentificacionUseCase(ITipoIdentificacionRepository tipoIdentificacionRepository)
        {
            this._tipoIdentificacionRepository = tipoIdentificacionRepository;
        }

        public async Task<List<TipoIdentificacionModel>> GetList()
        {
            return (await _tipoIdentificacionRepository.GetList()).OrderBy(x => x.Descripcion).ToList();
        }
    }
}
