using SixDegreesIt.DataAccess.Models;
using SixDegreesIt.Entities.Entities;

namespace SixDegreesIt.DataAccess.Helpers
{
    public class UserHelper : IUserHelper
    {
        public UsuarioEntity ModelToUserEntity(UserModel model)
        {
            return new UsuarioEntity
            {
                UsuId = model.Id,
                Nombre = model.FirstName,
                Apellido = model.LastName
            };
        }
    }
}
