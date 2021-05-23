using SixDegreesIt.Entities.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SixDegreesIt.DataAccess.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUsersAsync();
        }

        private async Task CheckUsersAsync()
        {
            if (!_context.Usuarios.Any())
            {
                AddUsuario("John", "Arevalo");
                AddUsuario("Samuel", "Pérez");
                AddUsuario("Valeria", "Sánchez");
                AddUsuario("Eliana", "Roso");
                AddUsuario("Miriam", "Tarazona");
                AddUsuario("Saul", "Sanguino");
                await _context.SaveChangesAsync();
            }
        }

        private void AddUsuario(string nombre, string apellido)
        {
            UsuarioEntity usuario = new()
            {
                Nombre = nombre,
                Apellido = apellido
            };
            _context.Usuarios.AddAsync(usuario);
        }
    }
}
