using SixDegreesIt.DataAccess.Models;
using SixDegreesIt.Entities.Entities;

namespace SixDegreesIt.DataAccess.Helpers
{
    public interface IUserHelper
    {
        UsuarioEntity ModelToUserEntity(UserModel model);
    }
}
