using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Domain.IServices
{
    public interface IUsuarioServicesPort
    {
        Task<UsuarioModel> CreateUser(UsuarioModel usuarioModel);
        Task<bool> Login(LoginModel loginModel);
    }
}
