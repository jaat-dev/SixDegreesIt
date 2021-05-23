using SixDegreesIt.Business.Models;
using SixDegreesIt.DataAccess.Models;

namespace SixDegreesIt.Business.Helpers
{
    public interface IModelHelper
    {
        UserModel RequestToModel(UserRequest request);
    }
}
