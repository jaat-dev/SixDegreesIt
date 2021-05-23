using Microsoft.EntityFrameworkCore;
using SixDegreesIt.Entities.Entities;

namespace SixDegreesIt.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }

    }
}
