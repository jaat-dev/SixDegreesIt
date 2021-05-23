using SixDegreesIt.Business.Models;
using SixDegreesIt.DataAccess.Models;

namespace SixDegreesIt.Business.Helpers
{
    public class ModelHelper : IModelHelper
    {
        public UserModel RequestToModel(UserRequest request)
        {
            return new UserModel
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.FirstName
            };
        }
    }
}
