using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Domain.IRepository
{
    public  interface ITipoIdentificacionRepository
    {
        Task<List<TipoIdentificacionModel>> GetList();
    }
}
