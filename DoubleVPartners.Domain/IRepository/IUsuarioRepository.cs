using DoubleVPartners.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleVPartners.Domain.IRepository
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> CreateUserAsync(UsuarioModel usuarioModel);
        Task<UsuarioModel> ValidateLoginAsync(LoginModel loginModel);
        Task<bool> ValidatUsereAsync(string Usuario);
    }
}
