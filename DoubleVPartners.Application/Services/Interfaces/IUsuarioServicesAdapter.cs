using DoubleVPartners.Application.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.Services.Interfaces
{
    public interface IUsuarioServicesAdapter
    {
        Task CreateUsuario(UsuarioRequestDTO usuarioRequest);
        Task<bool> Login(LoginDTO login);
    }
}
