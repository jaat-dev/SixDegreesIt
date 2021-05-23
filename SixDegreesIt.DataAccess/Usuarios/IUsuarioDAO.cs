using SixDegreesIt.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixDegreesIt.DataAccess.Usuarios
{
    public interface IUsuarioDAO
    {
        Task<IEnumerable<UsuarioEntity>> GetUsuariosAsync();
        Task<UsuarioEntity> GetUsuarioByIdAsync(int id);
        Task AddUserAsync(UsuarioEntity usuario);
        Task UpdateUserAsync(UsuarioEntity usuario);
        Task DeleteUserAsync(UsuarioEntity usuario);
    }
}
