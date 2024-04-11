using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Mapper;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.Services
{
    public class TipoIdentificacionServicesAdapter : ITipoIdentificacionServicesAdapter
    {
        private readonly ITipoIdentificacionServicesPort _tipoIdentificacionServicesPort;

        public TipoIdentificacionServicesAdapter(ITipoIdentificacionServicesPort tipoIdentificacionServicesPort)
        {
            this._tipoIdentificacionServicesPort = tipoIdentificacionServicesPort;
        }

        public async Task<List<TioIdentificacionResponseDTO>> List()
        {
            var model = (await _tipoIdentificacionServicesPort.GetList()).MapToModel<List<TioIdentificacionResponseDTO>>();
            return model;
        }
    }
}
