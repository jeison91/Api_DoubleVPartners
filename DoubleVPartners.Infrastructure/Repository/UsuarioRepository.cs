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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PartnersDbContext _dBContext;
        public UsuarioRepository(PartnersDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<UsuarioModel> CreateUserAsync(UsuarioModel usuarioModel)
        {
            var entity = usuarioModel.MapToEntity<UsuarioEntity>();
            _dBContext.Set<UsuarioEntity>().Add(entity);
            await _dBContext.SaveChangesAsync();

            return entity.MapToEntity<UsuarioModel>();
        }

        public async Task<UsuarioModel> ValidateLoginAsync(LoginModel loginModel)
        {
            var userEntity = await _dBContext.Usuarios.Where(u => u.Usuario == loginModel.Usuario && u.Pass == loginModel.Pass).FirstOrDefaultAsync();
            return userEntity.MapToEntity<UsuarioModel>();
        }

        public async Task<bool> ValidatUsereAsync(string Usuario)
        {
            return await _dBContext.Usuarios.Where(u => u.Usuario == Usuario).FirstOrDefaultAsync() == null;
        }
    }
}
