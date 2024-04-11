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
    public class UsuarioUseCase : IUsuarioServicesPort
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioModel> CreateUser(UsuarioModel usuarioModel)
        {
            //Validar si ya existe el usuario
            if (!await _usuarioRepository.ValidatUsereAsync(usuarioModel.Usuario))
                throw new DomainValidateException("Ya existe un registro con este usuario.");

            //Registar persona
            var resposeUsuarioModel = await _usuarioRepository.CreateUserAsync(usuarioModel);
            return resposeUsuarioModel;
        }

        public async Task<bool> Login(LoginModel loginModel)
        {
            //Validar si ya existe el usuario
            var loginEntity = await _usuarioRepository.ValidateLoginAsync(loginModel);

            if (loginEntity == null)
                throw new DomainValidateException("Usuario o contraseña incorrectos.");

            return true;
        }
    }
}
