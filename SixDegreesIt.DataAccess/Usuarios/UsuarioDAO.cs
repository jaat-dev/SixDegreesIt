using Microsoft.EntityFrameworkCore;
using SixDegreesIt.Entities.Entities;
using SixDegreesIt.DataAccess.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SixDegreesIt.DataAccess.Usuarios
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly DataContext _context;

        public UsuarioDAO(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioEntity>> GetUsuariosAsync() => await _context.Usuarios.ToListAsync();

        public async Task<UsuarioEntity> GetUsuarioByIdAsync(int id) => await _context.Usuarios.FindAsync(id);

        public async Task AddUserAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateUserAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
