using DoubleVPartners.Application.DTO.Request;
using DoubleVPartners.Application.DTO.Response;
using DoubleVPartners.Application.Mapper;
using DoubleVPartners.Application.Services.Interfaces;
using DoubleVPartners.Domain.IServices;
using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Application.Services
{
    public class UsuarioServicesAdapter : IUsuarioServicesAdapter
    {
        private readonly IUsuarioServicesPort _usuarioServicesPort;

        public UsuarioServicesAdapter(IUsuarioServicesPort usuarioServicesPort)
        {
            this._usuarioServicesPort = usuarioServicesPort;
        }

        public async Task CreateUsuario(UsuarioRequestDTO usuarioRequest)
        {
            var usuarioModel = usuarioRequest.MapToModel<UsuarioModel>();
            await _usuarioServicesPort.CreateUser(usuarioModel);
        }

        public async Task<bool> Login(LoginDTO login)
        {
            return await _usuarioServicesPort.Login(login.MapToModel<LoginModel>());
        }
    }
}
